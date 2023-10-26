using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PhoneDirectory
{
    public class Kisi
    {
        List<Kisi> Kisiler = new List<Kisi>();

        private string name, surName, phoneNumber; //Encapsulation

        public Kisi( string name, string surName, string phoneNumber ) //Constructor
        {
            this.Name = name;   
            this.SurName = surName; 
            this.Phone_Number = phoneNumber;
        }

        public string Name { get; set; }
        public string SurName { get; set;}
        public string Phone_Number { get; set;}  



    }
}
