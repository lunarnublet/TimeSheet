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
    public class DayTests
    {
        [TestMethod()]
        public void AddHoursTest()
        {
            Day d = new Day(new DateTime(2016, 6, 28));
            int expected = 21;


            d.SetHours(8, TimeIdentifier.REGULAR);
            d.SetHours(8, TimeIdentifier.VACATION);
            d.SetHours(7, TimeIdentifier.SICK);
            d.SetHours(6, TimeIdentifier.REGULAR);


            Assert.AreEqual(expected, d.TotalHours);
        }
    }
}