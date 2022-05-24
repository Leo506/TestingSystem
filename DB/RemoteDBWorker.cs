using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data;
using TestingSystem.Testing;
using System.Net;
using System.IO;
using System.Text.Json;

namespace TestingSystem.DB
{
    public class RemoteDBWorker : IDBWorker
    {
        public Test GetTest(string guid)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string login, string password)
        {
            string url = $"https://localhost:7198/testing/api/GetUser/{login}&{password}";
            Task<string> task = Request(url);

            string result = task.Result;

            var user = JsonSerializer.Deserialize(result, typeof(User));

            return (User)user;
        }

        public bool HasUser(string login, string password)
        {
            return true;
        }


        private static async Task<string> Request(string url)
        {
            string responseString = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.ServerCertificateValidationCallback = delegate { return true; };

            var response = await request.GetResponseAsync();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            return responseString;
        }
    }
}
