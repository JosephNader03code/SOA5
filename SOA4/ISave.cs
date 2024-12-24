using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA4
{
    internal interface ISave
    {
        public void SaveToTxtFile(string FName, string LName, string Phone, string VisaCard, int BirthYear, int Age, string Username, string Passowrd, string Id, double WalletBalance);
        public virtual void Verify(string CheckUsername, string CheckPassword)
        {
            // Base class logic
        }
        public virtual void Verify(string CheckUsername)
        {

            // Base class logic




        }
    }
}