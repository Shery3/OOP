using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_sigin
{
    class Program
    {
        class credentials
        {
            public string userName;
            public string password;

        }
        static void Main(string[] args)
        {
            
            string path = @"D:\PF\OOP\programs\LAB 3 TASKS\list sigin\users.txt";
            List<credentials> data = new List<credentials>();
            int option;
            do
            {
                load_data(data, path);
                Console.Clear();
                option = loginMenu();


                if (option == 1)
                {
                     signUp(path);
                    
                }

                if (option == 2)
                {
                    signIn(data);
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
            StreamWriter users = new StreamWriter(path,true);
            users.WriteLine(uname + "," + pswrd);
            users.Flush();
            users.Close();


        }

        static void signIn(List<credentials> data)
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
                    break;
                }

                else
                {
                    Console.WriteLine("INVALID USER");
                }
            }
            Console.ReadKey();

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
                     info.userName= parse_record(record, 1);
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


    }
}


