using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.WebService2 service2 = new localhost.WebService2();
            DateTime dateTime = DateTime.Now;
            //int month = Convert.ToInt32(dateTime.Day);
            //int monthdiff = 1 - month;




            int week = Convert.ToInt32(dateTime.DayOfWeek);
            ////本周第一天
            int dayspan = (-1) * week;
            //本周最后一天
            int daydiff = (-1) * week + 6;
            string dateStart;
            string dateEnd;

            ////week = (week == 0 ? (7 - 1) dayspan (week - 1));


            dateStart = dateTime.AddDays(dayspan).ToShortDateString();
            dateEnd = dateTime.AddDays(daydiff).ToShortDateString();

            //Console.WriteLine(service2.Test(dateStart, dateEnd));
            //localhost.SelectService service = new localhost.SelectService();
            service2.GetAll(dateStart, dateEnd);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine(service.GetUserCount());
           
            Console.ReadKey();
                
        }
    }
}
