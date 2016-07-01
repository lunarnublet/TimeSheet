using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public enum TimeIdentifier { REGULAR, SICK, VACATION, ENUMMAX }
    public class Day
    {
        public DateTime date;

        public Day(DateTime date)
        {
            this.date = date;
        }

        public float TotalHours
        {
            get 
            {
                float totalHours = 0;
                for(int i = 0; i < (int)TimeIdentifier.ENUMMAX; ++i)
                {
                    totalHours += hours[i];
                }
                return totalHours; 
            }
        }

        private float[] hours = new float[(int)TimeIdentifier.ENUMMAX];

        public float GetHours(TimeIdentifier type)
        {
            return hours[(int)type];
        }

        public void SetHours(float inputHours, TimeIdentifier type)
        {
            if ((inputHours % .25f) <= .00001 && (inputHours % .25f) >= -.00001)
            {
                if ((inputHours - hours[(int)type]) + TotalHours < 24.0f)
                {
                    hours[(int)type] = inputHours;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("hours", "Adding " + hours + " hours will make the total hours be over 24.");
                }
            }
            else
            {
                throw new FormatException("Hours put into the SetHours method must be in .25 hour increments.");
            }
        }
    }
}
