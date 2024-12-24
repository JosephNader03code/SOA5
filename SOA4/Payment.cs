using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SOA4
{
    internal class Payment
    {
     public Payment()  { }
        public void Deposit()
        {
            Console.WriteLine("Choose Payment Method:");
            Console.WriteLine("1. Vodafone Cash");
            Console.WriteLine("2. InstaPay");
            Console.WriteLine("3. Bank by Visa");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    VodafoneCash();
                    break;
                case 2:
                    InstaPay(); // Uncomment and implement if needed
                    break;
                case 3:
                    BankByVisa(); // Uncomment and implement if needed
                    break; 
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        // Vodafone Cash Method
        private void VodafoneCash()
        {
            int maxattemp = 2;
            int attempt = 0;
            while (attempt < maxattemp)
            {
                attempt++;
                Console.Write("For payment via Vodafone Cash, enter your username: ");
                string enteredUser = Console.ReadLine();

                if (VerifyUserExistsVoda(enteredUser))
                {
                    Console.Write("Enter the amount to deposit using Vodafone Cash: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    if (amount > 0)
                    {
                        if (AddAmountToUserVoda(enteredUser, amount))
                        {              //tarek.hamed , 505
                            Console.WriteLine($"Successfully deposited {amount} via Vodafone Cash.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update the user's balance. Please check the file structure.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                    }
                }
                else
                {
                    Console.WriteLine("User not found in the file.");
                    Console.WriteLine($"Invalid Visa number. You have {maxattemp - attempt} attempts remaining.");

                }
                Console.WriteLine("----------------------");
            }

        }
        private void InstaPay()
        {
            int maxattemp = 2;
            int attempt = 0;
            while (attempt < maxattemp)
            {
                attempt++;
                Console.Write("For payment via instapay Cash, enter your password: ");
                string enteredUser = Console.ReadLine();

                if (VerifyUserExistsInsta(enteredUser))
                {
                    Console.Write("Enter the amount to deposit using InstaPay Cash: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    if (amount > 0)
                    {
                        if (AddAmountToUserInsta(enteredUser, amount))
                        {
                            Console.WriteLine($"Successfully deposited {amount} via InstaPay Cash.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update the user's balance. Please check the file structure.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                    }
                }
                else
                {
                    Console.WriteLine("User not found in the file.");
                    Console.WriteLine($"Invalid Visa number. You have {maxattemp - attempt} attempts remaining.");

                }

            }
            Console.WriteLine("----------------------");
        }

        private void BankByVisa()
        {
            int maxattemp = 2;
            int attempt =0 ;
           while (attempt < maxattemp)
           {
            attempt++;
            Console.Write("For payment via BankVisa , enter your visanum: ");
            string visanum = Console.ReadLine();

            if (VerifyUserExistsBank(visanum))
            {
                Console.Write("Enter the amount to deposit using BankVisa Cash: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                if (amount > 0)
                {
                    if (AddAmountToUserBank(visanum, amount))
                    {
                        Console.WriteLine($"Successfully deposited {amount} via bankvisa Cash.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update the user's balance. Please check the file structure.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }
            else
            {
                Console.WriteLine("visanumber not found in the file.");
                Console.WriteLine($"Invalid Visa number. You have {maxattemp - attempt} attempts remaining.");

             }

            }

        }

        // Verifyifyserexists
        public bool VerifyUserExistsVoda(string enteredUser)
        {
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length > 6 && data[6] == enteredUser) // Adjust column index as needed
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        public bool VerifyUserExistsInsta(string enteredUser)
        {
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length > 6 && data[7] == enteredUser) // Adjust column index as needed
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool VerifyUserExistsBank(string enteredUser)
        {
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length > 6 && data[3] == enteredUser) // Adjust column index as needed
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        // Addamounttouserbalance
        public bool AddAmountToUserVoda(string CheckUsername, double amount)
        { //tarek.hamed,505
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                bool userFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    var data = lines[i].Split(',');

                    if (data.Length > 9 && data[6] == CheckUsername) // Adjust column index as needed
                    {
                        if (double.TryParse(data[9], out double currentAmount))
                        {
                            currentAmount += amount;
                            data[9] = currentAmount.ToString();
                            lines[i] = string.Join(",", data);
                            userFound = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid current balance in the file.");
                            return false;
                        }
                    }
                }

                if (userFound)
                {
                    File.WriteAllLines(filePath, lines); // Save updated file
                    return true;
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return false;
        }

        public bool AddAmountToUserInsta(string CheckUsername, double amount)
        { //3ae2e536,555
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                bool userFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    var data = lines[i].Split(',');

                    if (data.Length > 9 && data[7] == CheckUsername) // Adjust column index as needed
                    {
                        if (double.TryParse(data[9], out double currentAmount))
                        {
                            currentAmount += amount;
                            data[9] = currentAmount.ToString();
                            lines[i] = string.Join(",", data);
                            userFound = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid current balance in the file.");
                            return false;
                        }
                    }
                }

                if (userFound)
                {
                    File.WriteAllLines(filePath, lines); // Save updated file
                    return true;
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return false;
        }

        public bool AddAmountToUserBank(string CheckUsername, double amount)
        { //tarek.hamed,505
            string filePath = "students.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                bool userFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    var data = lines[i].Split(',');

                    if (data.Length > 9 && data[3] == CheckUsername) // Adjust column index as needed
                    {
                        if (double.TryParse(data[9], out double currentAmount))
                        {
                            currentAmount += amount;
                            data[9] = currentAmount.ToString();
                            lines[i] = string.Join(",", data);
                            userFound = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid current balance in the file.");
                            return false;
                        }
                    }
                }

                if (userFound)
                {
                    File.WriteAllLines(filePath, lines); // Save updated file
                    return true;
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return false;
        }

        // Print separator
        private void PrintSeparator()
            {
                Console.WriteLine(new string('*', 30));
            }
        }
    }


