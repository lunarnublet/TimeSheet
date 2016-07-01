using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Tests
{
    [TestClass()]
    public class EmployeeTests
    {
        [TestMethod()]
        public void AnotherTestTest()
        {
            Employee e = new Employee("12345")
            {
                FirstName = "Tryston",
                LastName = "Maris"
            };
            int expected = 23;


            e.Age = 23;


            Assert.AreEqual(expected, e.Age);
        }
    }
}