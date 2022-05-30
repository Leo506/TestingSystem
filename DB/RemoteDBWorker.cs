using System;
using TestingSystem.Data;
using TestingSystem.Models;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using System.Xml;
using System.Collections.Generic;

namespace TestingSystem.DB
{
    public class RemoteDBWorker : IDBWorker
    {
        public Test GetTest(string guid)
        {
            string url = Settings.Settings.GetSettings("baseUrl") + Settings.Settings.GetSettings("getTestUrl");
            url += $"{guid}";

            string response = GetResponse(url);

            XmlDocument xml = (XmlDocument)Newtonsoft.Json.JsonConvert.DeserializeXmlNode(response);

            return Utils.XmlToTestConverter.XmlToTest(xml);
        }

        public User GetUser(string login, string password)
        {
            string url = Settings.Settings.GetSettings("baseUrl") + Settings.Settings.GetSettings("getUserUrl");
            url += $"{login}&{password}";
            string result = GetResponse(url);

            var user = JsonSerializer.Deserialize<User>(result);


            return user;
        }


        public bool HasUser(string login, string password)
        {
            string url = Settings.Settings.GetSettings("baseUrl") + Settings.Settings.GetSettings("checkUserUrl");
            url += $"{login}&{password}";
            string result = GetResponse(url);

            return result == "true";
        }


        private static string GetResponse(string url)
        {
            Trace.WriteLine("Url: " + url);
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            var response = webRequest.GetResponse();

            string responseString = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                responseString = reader.ReadToEnd();
            }

            response.Close();
            Trace.WriteLine("Response: " + responseString);
            return responseString;
        }

        public List<TestInfo> GetPassedTests(int id)
        {
            throw new NotImplementedException();
        }
    }
}
