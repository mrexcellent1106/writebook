using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteBook
{
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Thirdname { get; set; }
        public string Phone_number { get; set; }
        public enum Country { Russia, Ukraine, Belarus, Kazakhstan, Other_Country };
        public Country citizenship = Country.Other_Country;
        public DateTime Birth_date = new DateTime(); 
        public string Org { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }
    }
}
