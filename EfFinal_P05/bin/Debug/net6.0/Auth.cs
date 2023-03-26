using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfFinal_P05
{
    internal class Auth
    {
        bool isLogined = false;
        private string Login { get; set; }
        private string Password { get; set; }

        public Auth()
        {
            string filePath = "C:/Users/Mykyta/source/repos/EfFinal_P05/EfFinal_P05/auth.json"; // Replace with the path to your file
            string jsonString = File.ReadAllText(filePath); // Read the contents of the file into a string

            JObject jsonObject = JObject.Parse(jsonString); // Parse the JSON string into a JObject
                    
            if ((string)jsonObject["LoginString"] == "" && (string)jsonObject["PasswordString"] == "")
            {
                Console.WriteLine("REGISTRATION");
                Console.Write("\tEnter Login:"); Login = Console.ReadLine(); jsonObject["LoginString"] = Login;
                Console.Write("\tEnter Password:");  Password = Console.ReadLine(); jsonObject["PasswordString"] = Password;
            }
            else
            {
                Login = (string)jsonObject["LoginString"];
                Password = (string)jsonObject["PasswordString"];
            }
        }
        public void UserLogin(string login, string password)
        {
            if (login != Login)
                Console.WriteLine("\t\tLogin uncorrect");
            if (password != Password)
                Console.WriteLine("\t\tPassword uncorrect");
            else
                Console.WriteLine("\t\tWelcome, login and password correct");
        }

    }
}
