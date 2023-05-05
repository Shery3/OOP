using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            //task1();
            //task2();
            //task3();
            //task4();
            //task5();
            //task6();
            //task7();
            //task8();
            //task9();
            //task10();
            //task11();
            //task12();
            //task13();
            task14();
            //Console.Write("Enter number1: ");
            //int num1=int.Parse(Console.ReadLine());
            //Console.Write("Enter number2: ");
            //int num2= int.Parse(Console.ReadLine());
            //int add=addition(num1, num2);
            //Console.WriteLine("The sum is: {0}",add);
            Console.ReadKey();
        }

        static void task1()
        {
            Console.Write("HELLO");
            Console.WriteLine("HELLO WORLD");
            Console.WriteLine("MY NAME IS SHEHROZ");
        }

        static void task2()
        {
            int var = 10;
            float var1 = 2.1F;
            string var2 = "i am string";
            char var3 = '@';
            Console.Write("VALUE OF var IS: ");
            Console.WriteLine(var);
            Console.Write("VALUE OF var1 IS: ");
            Console.WriteLine(var1);
            Console.Write("THE STRING IS: ");
            Console.WriteLine(var2);
            Console.Write("THE CHARACTER IS: ");
            Console.WriteLine(var3);

        }

        static void task3()
        {
            string input;
            Console.Write("ENTER THE INPUT: ");
            input = Console.ReadLine();
            Console.Write("YOU HAVE INPUTTED: ");
            Console.WriteLine(input);

        }

        static void task4()
        {
            string input1;
            Console.Write("ENTER THE INPUT: ");
            input1 = Console.ReadLine();
            Console.Write("THE STRING IS: ");
            Console.WriteLine(input1);

            int num;
            num = int.Parse(input1);
            Console.Write("THE INTEGER IS: ");
            Console.WriteLine(num);

        }

        static void task5()
        {
            string input2;
            Console.Write("ENTER THE INPUT: ");
            input2 = Console.ReadLine();
            Console.Write("THE STRING IS: ");
            Console.WriteLine(input2);

            float num;
            num = float.Parse(input2);
            Console.Write("THE FLOAT IS: ");
            Console.WriteLine(num);

        }

        static void task6()
        {
            Console.Write("ENTER THE LENGTH: ");
            float length = float.Parse(Console.ReadLine());
            float area = length * length;
            Console.Write("THE AREA IS: ");
            Console.WriteLine(area);

        }

        static void task7()
        {
            Console.Write("Enter the marks: ");
            int marks = int.Parse(Console.ReadLine());

            if (marks >= 50)
            {
                Console.Write("You are passed");
            }

            else
            {
                Console.Write("You are failed");
            }

        }

        static void task8()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Welcome Jack");
            }
        }

        static void task9()
        {
            int num;
            int sum = 0;

            Console.Write("Enter the number: ");
            num = int.Parse(Console.ReadLine());

            while (num != -1)
            {
                sum = sum + num;
                Console.Write("THE SUM IS: ");
                Console.WriteLine(sum);
                Console.Write("Enter the number: ");
                num = int.Parse(Console.ReadLine());

            }
        }
        static void task10()
        {
            int num;
            int sum = 0;

            do
            {
                Console.Write("Enter the number: ");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
                Console.Write("THE SUM IS: ");
                Console.WriteLine(sum);

            } while (num != -1);

        }

        static void task11()
        {
            int[] array = new int[3];
            int largest = -1;
            for (int idx = 0; idx < 3; idx++)
            {
                Console.WriteLine("ENTER THE ELEMENTS: ");
                array[idx] = int.Parse(Console.ReadLine());
            }

            for (int idx = 0; idx < 3; idx++)
            {
                if (array[idx] > largest)
                {
                    largest = array[idx];
                }

            }
            Console.Write("The largest number in the array is: ");
            Console.WriteLine(largest);
        }

        static int addition(int num1, int num2)
        {
            int sum;
            sum = num1 + num2;
            return sum;
        }

        static void task12()
        {
            string path = "D:\\PF\\OOP\\doc.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
            }

            else
            {
                Console.WriteLine("file does not exists");
            }

        }

        static void task13()
        {
            string path = "D:\\PF\\OOP\\doc.txt";
            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine("My regsitration no is 2022-CS-157");
            myFile.Flush();
            myFile.Close();
        }


        static void task14()
        {
            float age;
            float price;
            float toy_price;
            float amount = 0;
            float num = 1;
            float odd = 0;
            float toy;
            float total_price;
            float remaining_price;

            Console.Write(" Enter the age of lily: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Enter price of washing machine : ");
            price = float.Parse(Console.ReadLine());

            Console.Write("Enter the price of toy : ");
            toy_price = float.Parse(Console.ReadLine());

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    amount = amount + (10 * num);
                    num++;
                    amount = amount - 1;
                }
                if (i % 2 != 0)
                {
                    odd = odd + 1;

                }
            }
            toy = odd * toy_price;
            total_price = amount + toy;

            if (total_price > price)
            {

                remaining_price = total_price - price;
                Console.WriteLine("Yes!{0}", remaining_price);
            }
            if (total_price < price)
            {

                remaining_price = price - total_price;
                Console.WriteLine("No!{0}", remaining_price);
            }
            Console.ReadKey();


        }
    }




}

