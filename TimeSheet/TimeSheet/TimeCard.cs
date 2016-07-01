using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TimeSheet
{
    public class TimeCard
    {
        const int daysInPayPeriod = 14;
        private Day[] days = new Day[daysInPayPeriod];
        private Employee employee;
        private float overtimeWeek1;
        private float overtimeWeek2;

        public TimeCard(String EmployeeID, DateTime startDate)
        {
            if (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays((7 - (int)startDate.DayOfWeek));
            }
            for (int i = 0; i < daysInPayPeriod; ++i)
            {
                days[i] = new Day(startDate.AddDays(i));
            }
            employee = new Employee(EmployeeID);
        }

        public Day[] Days
        {
            get { return days; }
        }

        public Employee Emp
        {
            get { return employee; }
        }

        public float OvertimeWeek1
        {
            get { return overtimeWeek1; }
            private set
            {
                overtimeWeek1 = value;
            }
        }
        public float OvertimeWeek2
        {
            get { return overtimeWeek2; }
            private set
            {
                overtimeWeek2 = value;
            }
        }

        public float WeekTotal(DateTime WeekStart)
        {
            float total = 0;
            int startday = 0;
            if (WeekStart.Equals(days[7].date))
            {
                startday = 7;
                total += OvertimeWeek2;
            }
            else
            {
                total += OvertimeWeek1;
            }
            for (int i = startday; i < startday + 7; ++i)
            {
                total += days[i].TotalHours;
            }
            return total;
        }

        public float WeekTotalRegular(DateTime WeekStart)
        {
            float total = 0;
            int startday = 0;
            if (WeekStart.Equals(days[7].date))
            {
                startday = 7;
            }
            for (int i = startday; i < startday + 7; ++i)
            {
                total += days[i].GetHours(TimeIdentifier.REGULAR);
            }
            return total;
        }

        public float WeekTotalSick(DateTime WeekStart)
        {
            float total = 0;
            int startday = 0;
            if (WeekStart.Equals(days[7].date))
            {
                startday = 7;
            }
            for (int i = startday; i < startday + 7; ++i)
            {
                total += days[i].GetHours(TimeIdentifier.SICK);
            }
            return total;
        }

        public float WeekTotalVacation(DateTime WeekStart)
        {
            float total = 0;
            int startday = 0;
            if (WeekStart.Equals(days[7].date))
            {
                startday = 7;
            }
            for (int i = startday; i < startday + 7; ++i)
            {
                total += days[i].GetHours(TimeIdentifier.VACATION);
            }
            return total;
        }

        public float TimeCardTotal()
        {
            float total = 0;
            for (int i = 0; i < daysInPayPeriod; ++i)
            {
                total += days[i].TotalHours;
            }
            return total + OvertimeWeek1;
        }

        public float TimeCardTotalRegular()
        {
            float total = 0;
            for (int i = 0; i < daysInPayPeriod; ++i)
            {
                total += days[i].GetHours(TimeIdentifier.REGULAR);
            }
            return total;
        }

        public float TimeCardTotalSick()
        {
            float total = 0;
            for (int i = 0; i < daysInPayPeriod; ++i)
            {
                total += days[i].GetHours(TimeIdentifier.SICK);
            }
            return total;
        }

        public float TimeCardTotalVacation()
        {
            float total = 0;
            for (int i = 0; i < daysInPayPeriod; ++i)
            {
                total += days[i].GetHours(TimeIdentifier.VACATION);
            }
            return total;
        }


        public void AddHours(DateTime day, TimeIdentifier type, float hours)
        {

            switch (type)
            {
                case TimeIdentifier.SICK:
                    float SickTotal = WeekTotalSick(day.AddDays(-(int)day.DayOfWeek));

                    if (SickTotal + hours > 40.0f)
                    {
                        hours = 40 - SickTotal;
                    }
                    break;

                case TimeIdentifier.VACATION:
                    float VacTotal = WeekTotalVacation(day.AddDays(-(int)day.DayOfWeek));

                    if (VacTotal + hours > 40.0f)
                    {
                        hours = 40 - VacTotal;
                    }
                    break;
                case TimeIdentifier.REGULAR:
                    DateTime sunday = day.AddDays(-(int)day.DayOfWeek);
                    float RegTotal = WeekTotalRegular(sunday);
                    if ((RegTotal + hours) > 40.0f)
                    {
                        if (days[0].date.Equals(sunday))
                        {
                            OvertimeWeek1 = RegTotal + hours - 40.0f;
                        }
                        else
                        {
                            OvertimeWeek2 = RegTotal + hours - 40.0f;
                        }
                        
                        hours = 40 - RegTotal;
                    }
                    else
                    {
                        if (days[0].date.Equals(sunday))
                        {
                            OvertimeWeek1 = 0;
                        }
                        else
                        {
                            OvertimeWeek2 = 0;
                        }
                    }
                    break;
            }

            for (int i = 0; i < daysInPayPeriod; ++i)
            {
                if (day.Equals(days[i].date))
                {
                    days[i].SetHours(hours, type);
                    return;
                }
            }
            
        }
    }
}
