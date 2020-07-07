using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace aSem_lab1
{
    static class request
    {
        private static string host = "http://localhost:3221/";

        public static string Host { get => host; set => host = value; }

        static public string findIdUserByName(string login)
        {
            // Адрес ресурса, к которому выполняется запрос
            string url = host + "api/findIdUserByName?login=" + login;

            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                return response;
            }
        }
        static public string[] getMatrixr(string id)
        {
            // Адрес ресурса, к которому выполняется запрос
            string url = host + "api/GetMatrixlr?id=" + id;

            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                response = response.Replace("\\\"", "\"");
                response = response.Replace("\\", "");
                var responseSplit = JsonConvert.DeserializeObject<string[]>(response);
                return responseSplit;
            }
        }
        static public string getPasswordById(string idUser)
        {
            // Адрес ресурса, к которому выполняется запрос
            string url = host + "api/getPasswordById?idUser=" + idUser;

            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                return response;
            }
        }
        static public string registerUser(string login, string password)
        {
            // Адрес ресурса, к которому выполняется запрос
            string url = host + "api/registerUser?login=" + login + "&password="+ password;

            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                return response;
            }
        }
        
    }
}
