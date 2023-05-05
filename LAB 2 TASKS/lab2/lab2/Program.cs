using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        class students
        {
            public string stdName;
            public int stdRollNo;
            public float cGpa;
        }
        static void Main(string[] args)
        {
            //student1

            students s1 = new students();
            s1.stdName = "Shehroz";
            s1.stdRollNo = 157;
            s1.cGpa = 3.04F;
            Console.WriteLine("Data of Student 1: ");
            Console.WriteLine("Name: {0} ",s1.stdName);
            Console.WriteLine("Roll No: {0} ", s1.stdRollNo);
            Console.WriteLine("GPA: {0} ", s1.cGpa);
            Console.WriteLine();

            //student2

            students s2 = new students();
            s2.stdName = "Sami";
            s2.stdRollNo = 143;
            s2.cGpa = 3.3F;
            Console.WriteLine("Data of Student 2: ");
            Console.WriteLine("Name: {0} ", s2.stdName);
            Console.WriteLine("Roll No: {0} ", s2.stdRollNo);
            Console.WriteLine("GPA: {0} ", s2.cGpa);
            Console.WriteLine();

            //student3

            students s3 = new students();
            Console.WriteLine("For Student Input: ");
            Console.Write("Enter Your Name: ");
            s3.stdName = Console.ReadLine();
            Console.Write("Enter Your Roll no: ");
            s3.stdRollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Your GPA: ");
            s3.cGpa = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Data of Student 3: ");
            Console.WriteLine("Name: {0} ", s3.stdName);
            Console.WriteLine("Roll No: {0} ", s3.stdRollNo);
            Console.WriteLine("GPA: {0} ", s3.cGpa);
            Console.ReadKey();

        }
    }
}

