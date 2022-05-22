﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data;
using TestingSystem.Testing;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.Diagnostics;

namespace TestingSystem.DB
{
    public class LocalDBWorker : IDBWorker
    {
        private const string connectionString = "server=127.0.0.1;uid=root;password=26041986;database=TestingSystem";
        MySqlConnection connection;


        public LocalDBWorker()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public Test GetTest(string guid)
        {
            string sql = $"select path from Test where guid = {guid};";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var path = command.ExecuteScalar().ToString();
            if (path == null)
                return new Test();

            XDocument doc = XDocument.Load(path);
            var root = doc.Root;
            Test test = new Test();
            foreach (var item in root.Elements("Question"))
            {
                string text = item.Attribute("Text").Value;
                int countOfVariants = item.Elements("Var").Count();
                string[] variants = new string[countOfVariants];
                int index = 0;
                foreach (var v in item.Elements("Var"))
                {
                    variants[index] = v.Value;
                    index++;
                }
                string correctAnswer = item.Element("Correct").Value;

                Question question = new Question(variants, variants.ToList().IndexOf(correctAnswer), text);
                test.AddQuestion(question);
            }
            Trace.WriteLine("Is test empty: " + test.IsEmpty);
            return test;
        }

        public User GetUser(string login, string password)
        {
            string sql = $"select * from User where login = \"{login}\" and password = \"{password}\";";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();
            reader.Read();

            User user = new User() { Name = reader.GetString("Name"), CountOfTests = 0 };

            reader.Close();
            reader.Dispose();

            return user;
        }

        public bool HasUser(string login, string password)
        {
            string sql = $"select * from User where login = \"{login}\" and password = \"{password}\";";
            MySqlCommand command = new MySqlCommand(sql, connection);

            var reader = command.ExecuteReader();
            bool result = reader.HasRows;

            reader.Close();
            reader.Dispose();

            return result;
        }

        ~LocalDBWorker()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}