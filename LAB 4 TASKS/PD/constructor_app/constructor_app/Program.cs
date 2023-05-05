using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace constructor_app
{
    class Program
    {
        class MUser
        {
            public string name;
            public string password;
            public string role;

            public string pname;
            public int price;

            public MUser()
            {

            }
            public MUser(string name, string password)
            {
                this.name = name;
                this.password = password;
            }
            public MUser(string name, string password, string role)
            {
                this.name = name;
                this.password = password;
                this.role = role;
            }

            public MUser(string pname, int price)
            {
                this.pname = pname;
                this.price = price;

            }

            public MUser(int price)
            {
               
                this.price = price;

            }
            public bool isAdmin()
            {
                if (role == "Admin" || role=="admin")
                {
                    return true;
                }
                return false;
            }

            public bool isCustomer()
            {
                if (role == "Customer" || role == "customer")
                {
                    return true;
                }
                return false;
            }

            public void updatePricesOfProducts(List<MUser> data1)
            {
                int newPrices;
                Console.WriteLine("--> CHANGE THE PRICES ");
                Console.WriteLine(".....................");
                Console.WriteLine("");
                for (int idx = 0; idx < data1.Count; idx++)
                {
                    Console.Write("ENTER THE NEW PRICE OF {0}", data1[idx].name);
                    Console.Write(": ");
                    newPrices = int.Parse(Console.ReadLine());
                    data1[idx].price = newPrices;
                    Console.Write("THE NEW PRICE OF {0} ", data1[idx].name);
                    Console.WriteLine(" IS: {0}", data1[idx].price);
                    //MUser update =new MUser( data1[idx].price);
                    
                }
            }

            public void removeProducts(List<MUser> data1)
            {
                // int removeSize;
                // Console.Write("--> ENTER HOW MANY PRODUCT YOU WANT TO REMOVE: ");
                // removeSize = int.Parse(Console.ReadLine());
                // for (int idx = 0; idx < removeSize; idx++)
                // {
                //     Console.Write("--> ENTER THE NAME OF THE PRODUCT WHICH YOU WANT TO REMOVE: ");
                //     string removeProduct = Console.ReadLine();
                //     if (removeProduct == data1[idx].name)
                //     {
                //         data1[idx].name = " ";
                //         data1[idx].price = 0;
                //
                //         Thread.Sleep(300);
                //         Console.WriteLine("THE PRODUCT HAS BEEN REMOVED.");
                //     }
                // }
                //
                // Console.WriteLine("");
                // Console.WriteLine("--> PRODUCTS ");
                // Console.WriteLine("");
                //
                // for (int idx = 0; idx < data1.Count; idx++)
                // {
                //     if (data1[idx].name == " " && data1[idx].price == 0)
                //     {
                //         continue;
                //     }
                //     Console.WriteLine(data1[idx].name);
                //     Console.WriteLine(data1[idx].price);
                //     Console.WriteLine("");
                // }

                int index;
                Console.WriteLine("Enter the index of product you want to delete");
                index = int.Parse(Console.ReadLine());
                data1.RemoveAt(index);
            }

            public void changeAdminCredentials(List<MUser> data)
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
                    if ((oldUsername == data[idx].name) && (oldPassword == data[idx].password))
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
                    data[index].name = newUsername;
                    data[index].password = newPassword;
                    Thread.Sleep(300);
                    Console.Write("PASSWORD CHANGED SUCCESSFULLY.");
                }
                else if (flag == false)
                {
                    Console.WriteLine("SORRY..YOU HAVE ENTERED WRONG CREDENTIALS.");
                }
            }

            public void viewAllProducts(List<MUser> data1)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--> PRODUCTS ");
                Console.WriteLine("");
                for (int idx = 0; idx < data1.Count; idx++)
                {
                    Console.WriteLine("-->THE NAME OF PRODUCT IS:{0} ", data1[idx].name);
                    Console.Write("-->THE PRICE OF PRODUCT {0}", data1[idx].name);
                    Console.WriteLine(" IS:{0} ", data1[idx].price);
                    Console.WriteLine("");
                }
            }
        }

        static void Main(string[] args)
        {
            List<MUser> users = new List<MUser>();
            string path = @"D:\PF\OOP\programs\LAB 4 TASKS\PD\constructor_app\users.txt";
            string path1=@"D:\PF\OOP\programs\LAB 4 TASKS\PD\constructor_app\products.txt";
            List<MUser> products = new List<MUser>();
            MUser p = new MUser();
            int option;
            bool check = readData(path, users);
            readData1(path1, products);
            if (check)
                Console.WriteLine("DATA LOADED SUCCESSFULLY");
            else
                Console.WriteLine("DATA NOT LOADED");
            Console.ReadKey();
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    MUser user = takeInputWithoutRole();
                    if (user != null)
                    {
                        user = signIn(user, users);
                        if (user == null)
                        {
                            Console.WriteLine("INVALID USER");
                        }
                        else if (user.isAdmin())
                        {
                            Console.WriteLine("SIGNED IN SUCCESSFULLY..");
                            Console.ReadKey();
                            bool flag = true;
                            while (flag)
                            {
                                Console.Clear();
                                adminPage();
                                Console.Write("-->ENTER THE OPTION TO CONTINUE: ");
                                int adminoption = int.Parse(Console.ReadLine());

                                if (adminoption == 1)
                                {
                                    Console.Clear();
                                    MUser product = addProducts();
                                    storeProductsInFile(path1, product);
                                    storeProductsInList(products, product);
                                    Console.ReadKey();
                                }

                                if (adminoption == 2)
                                {
                                    Console.Clear();
                                    p.updatePricesOfProducts(products);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 3)
                                {
                                    Console.Clear();
                                    p.removeProducts(products);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 4)
                                {
                                    Console.Clear();
                                    p.changeAdminCredentials(users);
                                    Console.ReadKey();
                                }

                                else if (adminoption == 5)
                                {
                                    Console.Clear();
                                    p.viewAllProducts(products);
                                    Console.ReadKey();
                                }

                                else if (adminoption==6)
                                {
                                    flag = false;
                                }
                            }
                        }
                        else if (user.isCustomer())
                        {
                            Console.WriteLine("USER MENU");
                        }
                    }
                }
                else if (option == 2)
                {
                    MUser user = takeInputWithRole();
                    if (user != null)
                    {
                        storeDataInFile(path, user);
                        storeDataInList(users, user);
                    }
                }
                Console.ReadKey();
            }
            while (option < 3);
        }

        static int menu()
        {
            int option;
            Console.WriteLine("1. SIGN IN");
            Console.WriteLine("2. SIGN UP");
            Console.WriteLine("3. EXIT");
            Console.WriteLine("ENTER OPTION");
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

        static MUser addProducts()
        {
            Console.Clear();
            

            Console.Write("-->ENTER PRODUCT NAME: ");
            string pname = Console.ReadLine();

            Console.Write("-->ENTER THE PRODUCT'S PRICE: ");
            int price = int.Parse(Console.ReadLine());

            if(pname!=null && price>0)
            {
                MUser products = new MUser(pname, price);
                return products;
            }

            return null;
        }

        

        static MUser takeInputWithoutRole()
        {
            Console.WriteLine("ENTER NAME: ");
            string name = Console.ReadLine();
            Console.WriteLine("ENTER PASSWORD: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;

        }

        static MUser takeInputWithRole()
        {
            Console.WriteLine("ENTER NAME: ");
            string name = Console.ReadLine();
            Console.WriteLine("ENTER PASSWORD: ");
            string password = Console.ReadLine();
            Console.WriteLine("ENTER ROLE: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
            return null;
        }

        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        static void storeDataInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }

        static void storeProductsInList(List <MUser> products, MUser product)
        {
            products.Add(product);
        }

        static void storeDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }

        static void storeProductsInFile(string path1, MUser product)
        {
            StreamWriter file = new StreamWriter(path1, true);
            file.WriteLine(product.pname + "," + product.price);
            file.Flush();
            file.Close();
        }

        static MUser signIn(MUser user, List<MUser> users)
        {
            foreach (MUser storedUser in users)
            {
                if (user.name == storedUser.name && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }
        static bool readData(string path, List<MUser> users)

        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    MUser user = new MUser(name, password, role);
                    storeDataInList(users, user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }

        static bool readData1(string path1, List<MUser> products)

        {
            if (File.Exists(path1))
            {
                StreamReader fileVariable = new StreamReader(path1);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string pname = parseData(record, 1);
                    string price = parseData(record, 2);
                    MUser product = new MUser(pname,price);
                    storeProductsInList(products, product);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
    }
}
