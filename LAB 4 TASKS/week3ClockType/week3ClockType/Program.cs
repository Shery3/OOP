using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3ClockType
{
    class Program
    {
        class clockType
        {
            public int hours;
            public int minutes;
            public int seconds;
            public int etime;
            public int rtime;
            public clockType()
            {
                hours = 0;
                minutes = 0;
                seconds = 0;
            }

            public clockType(int h)
            {
                hours = h;
            }
            public clockType(int h, int m)
            {
                hours = h;
                minutes = m;
            }
            public clockType(int h, int m, int s)
            {
                hours = h;
                minutes = m;
                seconds = s;
            }

            public void incrementHours()
            {
                hours++;
            }
            public void incrementMinutes()
            {
                minutes++;
            }
            public void incrementSeconds()
            {
                seconds++;
            }

            public void printTime()
            {
                Console.WriteLine(hours + " " + minutes + " " + seconds);
            }

            public int elapsedTime()
            {
                 etime = (hours * 3600) + (minutes * 60) + seconds;
                return etime;
            }

            public void remainingTime()
            {
                 rtime = 86400 - ((hours * 3600) + (minutes * 60) + seconds);
                
            }

            public clockType differenceTime(clockType c)
            {
                clockType n = new clockType();
                n.hours = c.hours - hours;
                n.minutes = c.minutes - minutes;
                n.seconds = c.seconds - seconds;
                if (n.hours < 0)
                {
                    n.hours = -1 * n.hours;
                }
                if (n.minutes < 0)
                {
                    n.minutes = -1 * n.minutes;
                }
                if (n.seconds < 0)
                {
                    n.seconds = -1 * n.seconds;
                }
                return n;
            }
            
            public void conversion(int time)
            {
                int temp;
                hours = time / 3600;
                temp = time % 3600;
                minutes = temp / 60;
                seconds = temp % 60;
            }

            public bool isTrue(int h, int m, int s)
            {
                if (hours == h && minutes == m && seconds == s)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool isTrue(clockType temp)
            {
                if (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        static void Main(string[] args)
        {
            clockType initialTime = new clockType();
            Console.WriteLine("ENTER TIME: ");
            initialTime.printTime();

            clockType hourTime = new clockType(10);
            Console.WriteLine("ENTER HOUR TIME: ");
            hourTime.printTime();

            clockType minuteTime = new clockType(10, 12);
            Console.WriteLine("ENTER MINUTE TIME: ");
            minuteTime.printTime();

            clockType finalTime = new clockType(10, 12, 12);
            Console.WriteLine("ENTER SECOND TIME: ");
            finalTime.printTime();


            finalTime.incrementSeconds();
            Console.WriteLine("FULL TIME AFTER INCREMENTING SECONDS: ");
            finalTime.printTime();

            finalTime.incrementMinutes();
            Console.WriteLine("FULL TIME AFTER INCREMENTING MINUTES: ");
            finalTime.printTime();

            finalTime.incrementHours();
            Console.WriteLine("FULL TIME AFTER INCREMENTING HOUR: ");
            finalTime.printTime();

            bool flag = finalTime.isTrue(11, 13, 13);
            Console.WriteLine("FLAG: " + flag);

            clockType temp = new clockType(12, 14, 15);
            flag = finalTime.isTrue(temp);
            Console.WriteLine("FLAG: " + flag);

            clockType newtime = new clockType(10, 12, 12);
            newtime.elapsedTime();
            Console.WriteLine("ELAPSED TIME IN SECONDS IS: {0} ", newtime.etime);
            newtime.conversion(newtime.etime);
            Console.WriteLine("ELAPSED TIME IS: ");
            newtime.printTime();

            newtime.remainingTime();
            Console.WriteLine("REMAINING TIME IN SECONDS IS: {0}", newtime.rtime);
            newtime.conversion(newtime.rtime);
            Console.WriteLine("REMAINING TIME IS: ");
            newtime.printTime();

            clockType newClock = new clockType(10, 8, 5);
            clockType difference = new clockType();
            difference = newtime.differenceTime(newClock);
            Console.Write("TIME DIFFERENCE IN SECONDS: ");
            Console.WriteLine(newClock.elapsedTime());
            Console.Write("Time difference is: ");
            difference.printTime();

            Console.ReadKey();
        }
    }
}
