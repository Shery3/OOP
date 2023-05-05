using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace class_crud
{
    class Program
    {
        class credentials
        {
            public string userName;
            public string password;
            public string name;
            public int price;

        }
        static void Main(string[] args)
        {
            string path = @"D:\PF\OOP\programs\LAB 3 TASKS\list sigin\users.txt";
            string path1 = @"D:\PF\OOP\programs\LAB 3 TASKS\class crud\products.txt";
            int count = 0;
            List<credentials> data = new List<credentials>();
            credentials[] data1 = new credentials[10];
            int option;
            int adminoption;
            do
            {
                load_data(data, path);
                load_data1(data1, path1,count);
                Console.Clear();
                option = loginMenu();


                if (option == 1)
                {
                    signUp(path);
                    Console.WriteLine("SIGNED UP SUCCESSFULLY.");
                    Console.ReadKey();
                }

                else if (option == 2)
                {
                    string uname;
                    string pswrd;

                    Console.Clear();
                    Console.Write("-->ENTER USERNAME: ");
                    uname = Console.ReadLine();
                    Console.Write("-->ENTER PASSWORD: ");
                    pswrd = Console.ReadLine();

                    for (int index = 0; index < data.Count; index++)
                    {
                        if (data[index].userName == uname && data[index].password == pswrd)
                        {

                            Console.WriteLine("SIGNED IN SUCCESSFULLY.");


                            Console.ReadKey();

                            do
                            {
                                Console.Clear();
                                adminPage();
                                Console.Write("ENTER YOUR OPTION: ");
                                adminoption = int.Parse(Console.ReadLine());

                                if (adminoption == 1)
                                {
                                    Console.Clear();
                                    data1[count] = addProducts(path1);
                                    count++;
                                    Console.ReadKey();
                                }

                                else if (adminoption == 2)
                                {
                                    Console.Clear();
                                    updatePricesOfProducts(data1, count);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 3)
                                {
                                    Console.Clear();
                                    removeProducts(data1, count);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 4)
                                {
                                    Console.Clear();
                                    changeAdminCredentials(data);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 5)
                                {
                                    Console.Clear();
                                    viewAllProducts(data1, count);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 6)
                                {
                                    break;
                                }

                            } while (option != 6);
                        }

                    }

                }

                if (option == 3)
                {
                    break;
                }

            } while (option != 3);

        }
        static void signUp(string path)
        {
            Console.Clear();
            string uname;
            string pswrd;

            Console.Write("-->ENTER USERNAME: ");
            uname = Console.ReadLine();
            Console.Write("-->ENTER PASSWORD: ");
            pswrd = Console.ReadLine();
            StreamWriter users = new StreamWriter(path, true);
            users.WriteLine(uname + "," + pswrd);
            users.Flush();
            users.Close();


        }

        static void signIn(List<credentials> data)
        {

            string uname;
            string pswrd;
            bool flag = false;
            Console.Clear();
            Console.Write("-->ENTER USERNAME: ");
            uname = Console.ReadLine();
            Console.Write("-->ENTER PASSWORD: ");
            pswrd = Console.ReadLine();

            for (int index = 0; index < data.Count; index++)
            {
                if (data[index].userName == uname && data[index].password == pswrd)
                {
                    Console.WriteLine("SIGNED IN SUCCESSFULLY.");
                    flag = true;
                    break;
                }

            }
            if (flag == false)
            {
                Console.WriteLine("INVALID USER");
            }


        }

        static int loginMenu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("1. SIGN UP TO GET YOUR LOGIN CREDENTIALS");
            Console.WriteLine("2. SIGN IN WITH YOUR LOGIN CREDENTIALS");
            Console.WriteLine("3. EXIT THE APPLICATION");
            Console.WriteLine("");
            Console.Write("-->ENTER THE OPTION TO CONTINUE: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void adminPage()
        {
            Console.WriteLine("ADMIN MENU");
            Console.WriteLine(".....................");
            Console.WriteLine(" 1. ADD THE PRODUCTS.");
            Console.WriteLine(" 2. UPDATE THE PRICES OF THE PRODUCTS.");
            Console.WriteLine(" 3. REMOVE THE PRODUCTS.");
            Console.WriteLine(" 4. CHANGE LOGIN CREDENTIALS.");
            Console.WriteLine(" 5. VIEW PRODUCTS.");
            Console.WriteLine(" 6. EXIT.");
            Console.WriteLine("");

        }

        static credentials addProducts(string path1)
        {
            Console.Clear();
            credentials pdt1 = new credentials();

            Console.Write("-->ENTER PRODUCT NAME: ");
            pdt1.name = Console.ReadLine();

            Console.Write("-->ENTER THE PRODUCT'S PRICE: ");
            pdt1.price = int.Parse(Console.ReadLine());

            StreamWriter products = new StreamWriter(path1, true);
            products.WriteLine(pdt1.name + "," + pdt1.price);
            products.Flush();
            products.Close();


            return pdt1;
        }

        static void updatePricesOfProducts(credentials[] data1, int count)
        {
            int newPrices;
            Console.WriteLine("--> CHANGE THE PRICES ");
            Console.WriteLine(".....................");
            Console.WriteLine("");
            for (int idx = 0; idx < count; idx++)
            {
                Console.Write("ENTER THE NEW PRICE OF {0}", data1[idx].name);
                Console.Write(": ");
                newPrices = int.Parse(Console.ReadLine());
                data1[idx].price = newPrices;
                Console.Write("THE NEW PRICE OF {0} ", data1[idx].name);
                Console.WriteLine(" IS: {0}", data1[idx].price);
            }
        }

        static void removeProducts(credentials[] data1, int count)
        {
            int removeSize;
            Console.Write("--> ENTER HOW MANY PRODUCT YOU WANT TO REMOVE: ");
            removeSize = int.Parse(Console.ReadLine());
            for (int idx = 0; idx < removeSize; idx++)
            {
                Console.Write("--> ENTER THE NAME OF THE PRODUCT WHICH YOU WANT TO REMOVE: ");
                string removeProduct = Console.ReadLine();
                if (removeProduct == data1[idx].name)
                {
                    data1[idx].name = " ";
                    data1[idx].price = -1;

                    Thread.Sleep(300);
                    Console.WriteLine("THE PRODUCT HAS BEEN REMOVED.");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("--> PRODUCTS ");
            Console.WriteLine("");

            for (int idx = 0; idx < count; idx++)
            {
                if (data1[idx].name == " " && data1[idx].price == -1)
                {
                    continue;
                }
                Console.WriteLine(data1[idx].name);
                Console.WriteLine(data1[idx].price);
                Console.WriteLine("");
            }
        }

        static void changeAdminCredentials(List<credentials> data)
        {
            bool flag = false;
            string oldUsername;
            string oldPassword;
            string newUsername;
            string newPassword;
            int index = 0;

            Console.WriteLine("--> CHANGE CREDENTIALS ");
            Console.WriteLine(".....................");
            Console.WriteLine("");

            Console.Write("ENTER YOUR OLD USERNAME: ");
            oldUsername = Console.ReadLine();
            Console.Write("ENTER YOUR OLD PASSWORD: ");
            oldPassword = Console.ReadLine();
            Console.WriteLine("");

            for (int idx = 0; idx < data.Count; idx++)
            {
                if ((oldUsername == data[idx].userName) && (oldPassword == data[idx].password))
                {
                    index = idx;
                    flag = true;
                }
            }

            if (flag == true)
            {
                Console.Write("ENTER YOUR NEW USERNAME: ");
                newUsername = Console.ReadLine();
                Console.Write("ENTER YOUR NEW PASSWORD: ");
                newPassword = Console.ReadLine();
                data[index].userName = newUsername;
                data[index].password = newPassword;
                Thread.Sleep(300);
                Console.Write("PASSWORD CHANGED SUCCESSFULLY.");
            }
            else if (flag == false)
            {
                Console.WriteLine("SORRY..YOU HAVE ENTERED WRONG CREDENTIALS.");
            }
        }

        static void viewAllProducts(credentials[] data1, int count)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("--> PRODUCTS ");
            Console.WriteLine("");
            for (int idx = 0; idx < count; idx++)
            {
                Console.WriteLine("-->THE NAME OF PRODUCT IS:{0} ", data1[idx].name);
                Console.Write("-->THE PRICE OF PRODUCT {0}", data1[idx].name);
                Console.WriteLine(" IS:{0} ", data1[idx].price);
                Console.WriteLine("");
            }
        }


        static string parse_record(string record, int field)
        {
            int comma_count = 1;
            string item = "";
            for (int idx = 0; idx < record.Length; idx++)
            {
                if (record[idx] == ',')
                {
                    comma_count = comma_count + 1;
                }
                else if (comma_count == field)
                {
                    item = item + record[idx];
                }
            }
            return item;
        }
        static void load_data(List<credentials> data, string path)
        {

            string record;
            if (File.Exists(path))
            {
                StreamReader recordfile = new StreamReader(path);
                while ((record = recordfile.ReadLine()) != null)
                {
                    credentials info = new credentials();
                    info.userName = parse_record(record, 1);
                    info.password = parse_record(record, 2);
                    data.Add(info);
                }

                recordfile.Close();
            }

            else
            {
                Console.WriteLine("File does not exists");
            }
        }

        static void load_data1(credentials[] data1, string path1,int count)
        {
            string record;
            
            int idx = 0;
            if (File.Exists(path1))
            {
                StreamReader recordfile = new StreamReader(path1);
                while ((record = recordfile.ReadLine()) != null)
                {
                    credentials info = new credentials();
                    info.name = parse_record(record, 1);
                    info.price = int.Parse(parse_record(record, 2));
                    idx++;
                }

                count = idx;
                recordfile.Close();
            }

            else
            {
                Console.WriteLine("File does not exists");
            }
        }





    }
}


