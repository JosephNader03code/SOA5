using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA4
{
    internal class Display
    {
        public Display() { }

      /*  public overide void DisplayCourses()
        {
             void DisplayCourses(Dictionary<string, Tuple<string, string, double>> )
            {
                foreach (var i in courses)
                {
                    string courseName = i.Key; 
                    string instructor1 = i.Value.Item1; 
                    string instructor2 = i.Value.Item2; 
                    double price = i.Value.Item3;

                  
                    Console.WriteLine($"Course: {courseName}");
                    Console.WriteLine($"Instructor 1: {instructor1}");
                    Console.WriteLine($"Instructor 2: {instructor2}");
                    Console.WriteLine($"Price: {price}");
                    Console.WriteLine(); // لإضافة سطر فارغ بين الدورات
                }
            }

        }*/
        public virtual void DisplayUserDataWithMaskedPassword()
            {
               Console.Write("Enter the username to display data: ");
                string username = Console.ReadLine();
                string filePath = "students.txt";

                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    bool userFound = false;

                    foreach (var line in lines)
                    {
                        var data = line.Split(',');
                        if (data.Length > 8 && data[6] == username) 
                        {
                            data[7] = new string('*', data[7].Length);
                            data[3] = new string('*', data[3].Length);
                            Console.WriteLine("User Data (password and visa masked):");
                            Console.WriteLine(string.Join(",", data));
                            userFound = true;
                            break;
                        }
                    }

                    if (!userFound)
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
        

    }
}