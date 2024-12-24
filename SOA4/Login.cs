using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA4
{
    internal class Login 
    {
        public Login()
        {

        }
        public Student Student { get; set; }
        public string CheckUsername { get; set; }
        public string CheckPassword { get; set; }

        public bool CheckLogin()
        {
            Console.WriteLine("****************");
            Console.WriteLine("enter user name :");
            CheckUsername = Console.ReadLine();
            Console.WriteLine("enter your pass :");
            CheckPassword = Console.ReadLine();
            if (Verify(CheckUsername,CheckPassword))
            {
                Console.WriteLine("Login successful! Welcome back.");
                return true;
            }

            else
            {
       
                return false;
            }
            
        }
        public bool Verify(string CheckUsername, string CheckPassword)
        {
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length > 1 && data[6] == CheckUsername && data[7] == CheckPassword)
                    {
                        return true;

                    }

                }


            }
            else
            {
            }
           

            return false;
        }
    }
}

