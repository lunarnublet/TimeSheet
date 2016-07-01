using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class Employee
    {
        public Employee(string ID)
        {
            this.ID = ID;
        }

        public string ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string AnotherTest()
        {
            return "test";
        }
        
    }
}
