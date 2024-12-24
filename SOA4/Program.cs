using SOA4;
using System;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {

        Display dis = new Display();
        while (true)
        {
            
            Console.WriteLine("Welcome to the Student Management System!");
            Console.WriteLine("1 - Register as a new student");
            Console.WriteLine("2 - Log in");
            Console.Write("Choose an option (1 or 2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                Student student1 = new Student();
                Register register = new Register();
                register.Student = student1;
                register.Add();
                Console.WriteLine("Registration Successful! Press any key to return to the main menu.");
                Console.WriteLine("**---------------**");
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice == "2")
            {
                Console.Clear();
                int attempt = 0;
                int maxattempt = 2;
              while (attempt < maxattempt)
              {
                attempt++;
                Login login = new Login();
                  if (login.CheckLogin())
                  {
                    Console.WriteLine("Press any key to Continue to the main menu...");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine("Ready to Payment ?");
                        Console.ReadKey();
                        Payment payment = new Payment();
                        payment.Deposit();


                    dis.DisplayUserDataWithMaskedPassword();
                    Console.WriteLine("*******************");
                    Courses co = new Courses();
                        co.DisplayCourses();
                        co.SelectedCourse();

                        Console.WriteLine("*******************");
                        co.UpdateFileWithCourseSelection();
                        Console.ReadKey();
                        Console.Clear();
                        Exit();


                    }
                    else
                   {
                        Console.WriteLine($"wrong passowrd or user name .. try again . You have {maxattempt - attempt} attempts remaining.");
                        Console.WriteLine("Press any key to ...");
                        Console.ReadKey();
                     }
               }
                Console.WriteLine("*---**----**----*");


            }

            else
            {
               Console.WriteLine("Invalid option. Please choose again.");
                Console.WriteLine("Press any key to try again...");
                Console.WriteLine("*------------------*");

                Console.ReadKey();
            }
            break;
        }

         void Exit ()
        {
            Console.WriteLine("PRESS ANY THING TO OUT");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("exit");
           
        }
       

    }

    
}
