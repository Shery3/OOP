using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructor
{
    class Program
    {
        class student
        {
            public student()
            {
                name = "JILL";
                fscMarks = 933;
                matricMarks = 971;
                ecatMarks = 150;
                aggregate = 80.5F;
                //Console.WriteLine("default");
            }

            public student(string n)
            {
                name = n;
            }
            public student(string n, float f, float m, float e, float a)
            {
                name = n;
                fscMarks = f;
                matricMarks = m;
                ecatMarks = e;
                aggregate = a;
            }
            public student(student s3)
            {
                name = s3.name;
                fscMarks = s3.fscMarks;
                matricMarks = s3.matricMarks;
                ecatMarks = s3.ecatMarks;
                aggregate = s3.aggregate;
            }
            public string name;
            public float fscMarks;
            public float matricMarks;
            public float ecatMarks;
            public float aggregate;

        }

        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task3();
            //task4();
            //task5();
            task6();
            Console.ReadKey();
        }

        static void task1()
        {
            student s = new student();
            Console.WriteLine(s.name);
            Console.WriteLine(s.fscMarks);
            Console.WriteLine(s.matricMarks);
            Console.WriteLine(s.ecatMarks);
            Console.WriteLine(s.aggregate);
        }

        static void task2()
        {
            student s1 = new student();
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
        }
        static void task3()
        {
            student s = new student("SHEHROZ");
            Console.WriteLine(s.name);
            student s1 = new student("SAMI");
            Console.WriteLine(s1.name);

        }

        static void task4()
        {
            student s = new student("SHEHROZ", 933, 971, 150, 80.5F);
            Console.WriteLine(s.name);
            Console.WriteLine(s.fscMarks);
            Console.WriteLine(s.matricMarks);
            Console.WriteLine(s.ecatMarks);
            Console.WriteLine(s.aggregate);
            student s1 = new student("SAMI", 1000, 1020, 200, 88.5F);
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);

        }

        static void task5()
        {
            student s1 = new student();
            s1.name = "john";
            student s2 = new student(s1);
            Console.WriteLine(s1.name);
            Console.WriteLine(s2.name);
        }

        static void task6()
        {
            List<int> n = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int x in n)
            {
                Console.WriteLine(x);
            }
        }
        }
    }
