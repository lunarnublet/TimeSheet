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
    public class TimeCardTests
    {
        [TestMethod()]
        public void TimeCardTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 2));

            DateTime expected = new DateTime(2016, 7, 3);

            Assert.AreEqual(expected, c.Days[0].date);
        }

        [TestMethod()]
        public void WeekTotalTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 48.25f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.REGULAR, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.SICK, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.VACATION, 16);


            Assert.AreEqual(expected, c.WeekTotal(new DateTime(2016, 7, 3)));
        }

        [TestMethod()]
        public void WeekTotalRegularTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 40.0f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.REGULAR, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.REGULAR, 16);


            Assert.AreEqual(expected, c.WeekTotalRegular(new DateTime(2016, 7, 3)));
        }

        [TestMethod()]
        public void WeekTotalSickTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 40.0f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.SICK, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.SICK, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.SICK, 16);


            Assert.AreEqual(expected, c.WeekTotalSick(new DateTime(2016, 7, 3)));
        }

        [TestMethod()]
        public void WeekTotalVacationTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 23.25f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.VACATION, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.VACATION, 3);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.VACATION, 4);


            Assert.AreEqual(expected, c.WeekTotalVacation(new DateTime(2016, 7, 3)));
        }

        [TestMethod()]
        public void TimeCardTotalTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 96.5f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.REGULAR, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 11), TimeIdentifier.REGULAR, 16.25f);
            c.AddHours(new DateTime(2016, 7, 12), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 13), TimeIdentifier.SICK, 16);


            Assert.AreEqual(expected, c.TimeCardTotal());
        }

        [TestMethod()]
        public void TimeCardTotalRegularTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 80.0f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.REGULAR, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 11), TimeIdentifier.REGULAR, 16.25f);
            c.AddHours(new DateTime(2016, 7, 12), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 13), TimeIdentifier.REGULAR, 16);


            Assert.AreEqual(expected, c.TimeCardTotalRegular());
        }

        [TestMethod()]
        public void TimeCardTotalSickTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 80.0f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.SICK, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.SICK, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.SICK, 16);
            c.AddHours(new DateTime(2016, 7, 11), TimeIdentifier.SICK, 16.25f);
            c.AddHours(new DateTime(2016, 7, 12), TimeIdentifier.SICK, 16);
            c.AddHours(new DateTime(2016, 7, 13), TimeIdentifier.SICK, 16);


            Assert.AreEqual(expected, c.TimeCardTotalSick());
        }

        [TestMethod()]
        public void TimeCardTotalVacationTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));
            float expected = 80.0f;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.VACATION, 16.25f);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.VACATION, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.VACATION, 16);
            c.AddHours(new DateTime(2016, 7, 11), TimeIdentifier.VACATION, 16.25f);
            c.AddHours(new DateTime(2016, 7, 12), TimeIdentifier.VACATION, 16);
            c.AddHours(new DateTime(2016, 7, 13), TimeIdentifier.VACATION, 16);


            Assert.AreEqual(expected, c.TimeCardTotalVacation());
        }

        [TestMethod()]
        public void AddHoursTest()
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016,7,3));
            float expected = 8;


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.REGULAR, 16);


            Assert.AreEqual(expected, c.OvertimeWeek1);
        }
    }
}