using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOA4
{
    internal class Courses
    {
        string saveelmada = string.Empty;
        string saveElhi2ol = string.Empty;

        Dictionary<string, Tuple<string, string, double>> AvailableCourses = new Dictionary<string, Tuple<string, string, double>>()
        {
            { "Programing", new Tuple<string, string, double>("Mahmoud Ismail", "Asmaa", 2000.00) },
            { "Digital", new Tuple<string, string, double>("Mahmoud Gamal", "David", 2000.00) },
            { "Comuiniaction", new Tuple<string, string, double>("Aml", "Rofael Wasfy", 2000.00) },
            { "Data", new Tuple<string, string, double>("Yossef ElSheimy", "Yassen Ramadan", 2000.00) }
        };

        public void DisplayCourses()
        {
            Console.Clear();
            foreach (var i in AvailableCourses)
            {
                Console.WriteLine($"Course: {i.Key}");
                Console.WriteLine($"Instructor 1: {i.Value.Item1}");
                Console.WriteLine($"Instructor 2: {i.Value.Item2}");
                Console.WriteLine($"Price: {i.Value.Item3}");
                Console.WriteLine(" ");
            }
        }

        public void SelectedCourse()
        {
            Console.WriteLine("Enter the course you need: ");
            saveelmada = Console.ReadLine();

            foreach (var i in AvailableCourses)
            {
                if (saveelmada == i.Key)
                {
                    Console.WriteLine($"We found your subject: {saveelmada}");
                    break;
                }
            }

            Console.WriteLine("Enter the instructor you need: ");
            saveElhi2ol = Console.ReadLine();

            foreach (var i in AvailableCourses)
            {
                if (saveElhi2ol == i.Value.Item1 || saveElhi2ol == i.Value.Item2)
                {
                    Console.WriteLine($"We found your instructor: {saveElhi2ol}");
                    break;
                }
            }
            Console.WriteLine($"Course you chose: {saveelmada}, Instructor: {saveElhi2ol}, Price: 2000");
        }

    /*    public void UpdateFileWithCourseSelection()
        {
            string filePath = "students.txt";
            bool userFound = false;
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("Enter username to enroll in the course and instructor in the data file: ");
            string Username = Console.ReadLine();

            // Search for the line containing the username
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                string username = parts[6];  // Assuming username is the 7th column

                if (username == Username)
                {
                    // Deduct the price from the student's balance
                    double WalletBalance = Convert.ToDouble(parts[9]); // Assuming WalletBalance is the 10th column
                    WalletBalance -= 2000;
                    parts[2] = new string('*', parts[2].Length);
                    parts[3] = new string('*', parts[3].Length);
                    // Update the line with the new data
                    lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},{parts[4]},{parts[5]},{Username},{parts[7]},{parts[8]},{WalletBalance},{saveElhi2ol},{saveelmada}";

                    // Print the updated line to confirm
                    Console.WriteLine($"Updated Line: {lines[i]}");

                    userFound = true;
                    break;
                }
            }

            // If the user is found and updated, write the modified data back to the file
            if (userFound)
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("File updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    */
        public void UpdateFileWithCourseSelection()
        {
            string filePath = "students.txt";
            bool userFound = false;
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("Enter username to enroll in the course and instructor in the data file: ");
            string Username = Console.ReadLine();

            // Search for the line containing the username
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                // Ensure there are enough columns (at least 10) in the line
                if (parts.Length >= 10)
                {
                    string username = parts[6];  // Assuming username is the 7th column

                    if (username == Username)
                    {
                        // Deduct the price from the student's balance
                        double WalletBalance = Convert.ToDouble(parts[9]); // Assuming WalletBalance is the 10th column
                        WalletBalance -= 2000;
                        parts[2] = new string('*', parts[2].Length);
                        parts[3] = new string('*', parts[3].Length);
                        // Update the line with the new data
                        lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},{parts[4]},{parts[5]},{Username},{parts[7]},{parts[8]},{WalletBalance},{saveElhi2ol},{saveelmada}";

                        // Print the updated line to confirm
                        Console.WriteLine($"Updated Line: {lines[i]}");

                        userFound = true;
                        break;
                    }
                }
                else
                {
                   // Console.WriteLine($"Skipping line {i} because it doesn't have enough columns.");
                }
            }

            // If the user is found and updated, write the modified data back to the file
            if (userFound)
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("File updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

    }
}
