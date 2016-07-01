using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeCard c = new TimeCard("12345", new DateTime(2016, 7, 3));


            c.AddHours(new DateTime(2016, 7, 4), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 5), TimeIdentifier.REGULAR, 16);
            c.AddHours(new DateTime(2016, 7, 6), TimeIdentifier.REGULAR, 16);

        }
    }
}
