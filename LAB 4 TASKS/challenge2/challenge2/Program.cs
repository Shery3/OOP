using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge2
{
    class Program
    {
        class product
        {

            public product addproduct(product p)
            {
                Console.WriteLine("Enter name of Product:");
                p.nameofproduct = Console.ReadLine();
                Console.WriteLine("Enter Product category:");
                p.productcategory = Console.ReadLine();
                Console.WriteLine("Enter Product Price:");
                p.productprice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Stock Quantity:");
                p.stockquantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Minimum Product Stock Quantity:");
                p.minstockquan = int.Parse(Console.ReadLine());
                return p;

            }

            public int optionmenu()
            {
                int option;
                Console.WriteLine("1.Add Product");
                Console.WriteLine("2.View Product");
                Console.WriteLine("3.Product with Highest price ");
                Console.WriteLine("4.View Sales Tax pf all Products");
                Console.WriteLine("5.View Products to be ordered");
                Console.WriteLine("6.Exit");
                option = int.Parse(Console.ReadLine());
                return option;
            }


            public string nameofproduct;
            public string productcategory;
            public double productprice;
            public int stockquantity;
            public int minstockquan;
            public double salestax;

        }
        static void Main(string[] args)
        {
            int option;
            List<product> products = new List<product>();

            do
            {
                Console.Clear();
                product o = new product();
                option = o.optionmenu();
                Console.Clear();
                if (option == 1)
                {
                    product p = new product();
                    products.Add(p.addproduct(p));
                    Console.ReadKey();
                }

                else if (option == 2)
                {
                    viewproducts(products);
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    highestprice(products);
                    Console.ReadKey();

                }
                else if (option == 4)
                {
                    salestax(products);
                    Console.ReadKey();
                }

                else if (option == 5)
                {
                    threshold(products);
                    Console.ReadKey();
                }

                else if (option == 6)
                {
                    break;
                }
            }
            while (option < 6);
            Console.Read();
        }

        static void viewproducts(List<product> products)
        {
            Console.Clear();
            for (int idx = 0; idx < products.Count; idx++)
            {
                Console.WriteLine("Name of Product : {0} , Category of Product :{1} , Price of Product : {2} , Stock Quantity : {3} , Minimum Stock Quantity : {4}", products[idx].nameofproduct, products[idx].productcategory, products[idx].productprice, products[idx].stockquantity, products[idx].minstockquan);
            }

        }

        static void highestprice(List<product> products)
        {

            double highest = -1;
            string highest2 = "";
            for (int idx = 0; idx < products.Count - 1; idx++)
            {
                if (highest < products[idx].productprice)
                {
                    highest = products[idx].productprice;
                    highest2 = products[idx].nameofproduct;
                }
            }
            Console.WriteLine("Highest Product name : {0}     Highest Product Price : {1} ", highest2, highest);

        }

        static void salestax(List<product> products)
        {

            for (int idx = 0; idx < products.Count; idx++)
            {
                if (products[idx].productcategory == "grocery")
                {
                    products[idx].salestax = (products[idx].productprice * 0.1) + products[idx].productprice;

                }

                else if (products[idx].productcategory == "fruit")
                {
                    products[idx].salestax = (products[idx].productprice * 0.05) + products[idx].productprice;
                }
                else
                {
                    products[idx].salestax = (products[idx].productprice * 0.15) + products[idx].productprice;
                }

                Console.WriteLine("Sales Tax of Product  {0}  is  {1} ", products[idx].nameofproduct, products[idx].salestax);
            }
        }

        static void threshold(List<product> products)
        {
            for (int idx = 0; idx < products.Count; idx++)
            {
                if (products[idx].stockquantity <= products[idx].minstockquan)
                {
                    Console.WriteLine("Product {0} is on the the ORDER LIST", products[idx].nameofproduct);
                }

                else
                {
                    Console.WriteLine("ENOUGH STOCK of the Product {0} ", products[idx].nameofproduct);
                }
            }


        }
    }
}