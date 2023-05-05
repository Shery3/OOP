using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{
    class Program
    {
        class students
        {
            public string stdName;
            public int rollNo;
            public float gpa;
            public char isHostelide;
            public string department;
        }
        static void Main(string[] args)
        {
            int option;
            int count = 0;
            students[] data = new students[10];
            do
            {
                option = menu();
                
                Console.Clear();
                if (option == 1)
                {
                    data[count] = addStudent();
                    count++;
                }

                else if (option == 2)
                {
                    viewStudents(data, count);
                }

                else if(option == 3)
                {
                    topStudent(data, count);
                }

                else if(option==4)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("INVALID CHOICE.");
                }
                
                
            } while (option != 4);
            Console.ReadKey();
        }

        static int menu()
        {
            int option;
            Console.Clear();
            Console.WriteLine("--> YOUR OPTIONS: ");
            Console.WriteLine("1) ADD STUDENT");
            Console.WriteLine("2) SHOW STUDENTS");
            Console.WriteLine("3) TOP STUDENT");
            Console.WriteLine("4) EXIT");
            Console.WriteLine();
            Console.Write("ENTER YOUR OPTION: ");
            option = int.Parse(Console.ReadLine());
            Console.Write("Press any key to continue.");
            Console.ReadKey();

            return option;

        }

        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.Write("Enter Your Name: ");
            s1.stdName = Console.ReadLine();

            Console.Write("Enter Your RollNo: ");
            s1.rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Your GPA: ");
            s1.gpa = float.Parse(Console.ReadLine());

            Console.Write("Are You A Hostelide?( y || n ): ");
            s1.isHostelide = char.Parse(Console.ReadLine());

            Console.Write("Enter Your Department: ");
            s1.department = Console.ReadLine();

            Console.Write("Press any key to continue.");
            Console.ReadKey();

            return s1;

        }

        static void viewStudents(students[] data, int count)
        {
            Console.Clear();
            Console.WriteLine("--> STUDENTS ");

            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Data of Student {0}: ", x+1);
                Console.WriteLine("Name: {0} ", data[x].stdName);
                Console.WriteLine("Roll No: {0} ", data[x].rollNo);
                Console.WriteLine("GPA: {0} ", data[x].gpa);
                Console.WriteLine("Is Hostelide: {0} ", data[x].isHostelide);
                Console.WriteLine("Department: {0} ", data[x].department);
                Console.WriteLine();
            }
            Console.Write("Press any key to continue.");
            Console.ReadKey();

        }

        static void topStudent(students[] data, int count)
        {
            Console.Clear();
            if(count==0)
            {
                Console.WriteLine("No Record Found!");
            }

            if(count==1)
            {
                viewStudents(data, count);
            }

            if(count==2)
            {
                for(int x=0;x<2;x++)
                {
                    int idx = largest(data, x, count);
                    students temp = data[idx];
                    data[idx] = data[x];
                    data[x] = temp;
                }
                viewStudents(data, 2);
            }

            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int idx = largest(data, x, count);
                    students temp = data[idx];
                    data[idx] = data[x];
                    data[x] = temp;
                }
                viewStudents(data, 3);
            }
        }

        static int largest(students[] data,int start,int end)
        {
            int idx = start;
            float large = data[start].gpa;
            for(int x=start;x<end;x++)
            {
                if(data[x].gpa > large)
                {
                    large = data[x].gpa;
                    idx = x;
                }
            }
            return idx;
            
        }
    }
}
