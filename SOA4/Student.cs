using System;

namespace SOA4
{

    public class Student 
    {
        public Student()
        {}
     //   public Register register1 ;

        public  string FName { get; set; }


        public string LName { get; set; }


        public string Phone { get; set; }
        public string VisaCard { get; set; }

        public string Username { get; set; }

        public string Passowrd { get; set; }

        public int BirthYear { get; set; }

        public int Age { get; set; }
        public string Id { get; set; }

        public double WalletBalance { get; set; }

        public int YearOfBorn(int BirthYear)
        {
           return DateTime.Now.Year - BirthYear;
        }
        public virtual void SaveToTxtFile(string FName, string LName, string Phone, string VisaCard, int BirthYear, int Age, string Username, string Passowrd, string Id , double WalletBalance)
        {
            using (StreamWriter writer = new StreamWriter("students.txt", true))
            {
                writer.WriteLine($"{FName},{LName},{Phone},{VisaCard},{BirthYear},{Age},{Username},{Passowrd},{Id},{WalletBalance}");
            }
        }
     


    }
}