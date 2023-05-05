using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_classes
{
    class Program
    {
        class applications
        {
            public string userID;
            public string name;
            public int price;
            public string category;
            public string brandName;
            public string country;

        }
        static void Main(string[] args)
        {
            int option;
            int count = 0;
            applications[] data = new applications[10];
            do
            {
                option = menu();

                Console.Clear();
                if (option == 1)
                {
                    data[count] = addProducts();
                    count++;
                }

                else if (option == 2)
                {
                    viewAllProducts(data, count);
                }
                
                 else if (option == 3)
                 {
                     totalStoreWorth(data, count);
                 }

                else if (option == 4)
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
            Console.WriteLine("MENU");
            Console.WriteLine(".....................");
            Console.WriteLine(" 1. ADD THE PRODUCTS.");
            Console.WriteLine(" 2. VIEW PRODUCTS.");
            Console.WriteLine(" 3. TOTAL STORE WORTH.");
            Console.WriteLine(" 4. EXIT.");
            Console.WriteLine("");
            Console.Write("-->ENTER THE OPTION TO CONTINUE: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static applications addProducts()
        {
            Console.Clear();
            applications pdt1 = new applications();
            Console.Write("-->ENTER USER ID: ");
            pdt1.userID = Console.ReadLine();

            Console.Write("-->ENTER PRODUCT NAME: ");
            pdt1.name = Console.ReadLine();

            Console.Write("-->ENTER THE PRODUCT'S PRICE: ");
            pdt1.price = int.Parse(Console.ReadLine());

            Console.Write("-->ENTER CATEGORY: ");
            pdt1.category = Console.ReadLine();

            Console.Write("-->ENTER BRAND NAME: ");
            pdt1.brandName = Console.ReadLine();

            Console.Write("-->ENTER COUNTRY NAME: ");
            pdt1.country = Console.ReadLine();

            return pdt1;
        }

        static void viewAllProducts(applications[] data, int count)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("--> PRODUCTS ");
            Console.WriteLine(".....................");
            Console.WriteLine("");
            for (int idx = 0; idx < count; idx++)
            {
                Console.WriteLine("-->PRODUCT NO.{0} IS", idx+1);
                Console.WriteLine("");
                Console.WriteLine("-->THE USER ID IS: {0} ", data[idx].userID);
                Console.WriteLine("");
                Console.WriteLine("-->THE NAME OF PRODUCT IS: {0} ", data[idx].name);
                Console.WriteLine("");
                Console.WriteLine("-->THE PRICE OF PRODUCT: {0}", data[idx].price);
                Console.WriteLine("");
                Console.WriteLine("-->THE NAME OF CATEGORY IS: {0} ", data[idx].category);
                Console.WriteLine("");
                Console.WriteLine("-->THE NAME OF BRAND IS: {0} ", data[idx].brandName);
                Console.WriteLine("");
                Console.WriteLine("-->THE NAME OF COUNTRY IS: {0} ", data[idx].country);
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        static void totalStoreWorth(applications[] data, int count)
        {
            Console.Clear();
            int sum=0;
            Console.WriteLine("TOTAL STORE WORTH");
            Console.WriteLine(".....................");
            Console.WriteLine("");
            for (int x = 0; x < count; x++)
            {
                sum =  sum + data[x].price;
                
            }

            Console.WriteLine("SUM OF ALL ADDED PRODUCTS IS: {0} ", sum);
            Console.ReadKey();
        }
    }
}
