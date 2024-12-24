using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SOA4
{
    public class Register
    {
      

        public Register()
        {
            
        }
        public Student Student { get; set; }
        internal void Add()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Register as a New Student");
            Console.Write("Enter First Name: ");
            Student.FName = Console.ReadLine();
            Console.Write("Enter last Name: ");
            Student.LName = Console.ReadLine();
            Console.WriteLine("Enter Phone: ");
            Student.Phone =Console.ReadLine(); 
            Console.WriteLine(" Enter VisaCard ");
            Student.VisaCard =Console.ReadLine();
            Console.WriteLine(" Enter the year was born : ");
            Student.BirthYear = int.Parse(Console.ReadLine());
            Student.Age = Student.YearOfBorn(Student.BirthYear);
            Console.WriteLine($"You were born in {Student.BirthYear}, so your age = {Student.Age}");

            Student.Username = $"{Student.FName.ToLower()}.{Student.LName.ToLower()}";
            Student.Passowrd = Guid.NewGuid().ToString().Substring(0, 8);
            Student.Id = Guid.NewGuid().ToString().Substring(0, 2);
            Student.WalletBalance = 0;
            Console.WriteLine($"your user name : '{Student.Username}' and your passowrd : '{Student.Passowrd}' and ID : '{Student.Id}' and wallet balance = {Student.WalletBalance} ");

            Student.SaveToTxtFile(Student.FName, Student.LName, Student.Phone, Student.VisaCard, Student.BirthYear, Student.Age, Student.Username, Student.Passowrd, Student.Id , Student.WalletBalance);
            Console.WriteLine("Student data has been saved to the file.");
            Console.WriteLine("********************");

        }


    }
}