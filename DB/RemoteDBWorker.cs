using System;
using TestingSystem.Data;
using TestingSystem.Testing;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

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
    }
}
