using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_signup
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
            int count=0;
            credentials[] data = new credentials[10];
            int option;
            do
            {
                option = loginMenu();


                if (option == 1)
                {
                    data[count] = signUp();
                    count++;
                }

                if (option == 2)
                {
                    signIn(data, count);
                }

                if(option==3)
                {
                    break;
                }

            } while (option != 3);
        }

        static credentials signUp()
        {
            Console.Clear();
            credentials user1 = new credentials();
            Console.Write("-->ENTER USERNAME: ");
            user1.userName = Console.ReadLine();
            Console.Write("-->ENTER PASSWORD: ");
            user1.password = Console.ReadLine();
            Console.ReadKey();
            return user1;

        }

        static void signIn(credentials[] data, int count)
        {

            string uname;
            string pswrd;
            Console.Clear();
            Console.Write("-->ENTER USERNAME: ");
            uname = Console.ReadLine();
            Console.Write("-->ENTER PASSWORD: ");
            pswrd = Console.ReadLine();

            for (int index = 0; index < count; index++)
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
    }
}
