using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Dse;


namespace UsersList
{
    internal class Program
    {   

        static DBControll controller = new DBControll();

        static void Main(string[] args)
        {

            

            
               
            //   username,    firstname,  lastname,   age,    phone
            List<string> user = new List<string>();
            List<List<string>> usersList = new List<List<string>>();
            

            bool exit = false;
            while (exit != true)
            {
                //clear screen and show main menu
                showMainMenu();
                
                
                //get user choice
                switch (getKey())
                {
                    case '1': //add user
                    case 'a':
                    case 'A':
                        addUser();
                        getKey();
                        break;


                    case '2': //search user
                    case 's':
                    case 'S':

                        break;


                    case '3': //delete user

                        break;


                    case '4': //show users

                        break;


                    case '5': //save users

                        break;


                    case '6': //load users

                        break;


                    case '0'://exit
                    case 'q':
                    case 'Q':
                    case '7':
                        exit = true;

                        clearPrint("Bye!");

                        break;


                    default:
                        clearPrint("Wrong choice!");
                        Console.ReadKey();
                        break;

                }


            }



            


        }


        


        /// <summary>
        /// clear screen and print main menu
        /// </summary>
        static void showMainMenu()
        {
            clearPrint("----MENU----\n" +
                        "1.Add user(A)\n" +
                        "2.Search user(S)\n" +
                        "3.Delete user\n" +
                        "4.Show users\n" +
                        "5.Save users to a file\n" +
                        "6.Load users from a file\n" +
                        "7.Exit(0, Q)");

        }
        
        /// <summary>
        /// clear screen and print search menu
        /// </summary>
        static void showSearchMenu()
        {
            clearPrint("----SEARCH----\n" +
                        "1.by Username(U)\n" +
                        "2.by First Name(F)\n" +
                        "3.by Last Name(L)\n" +
                        "4.by Age(A)\n" +
                        "5.by Phone(P)\n" +
                        "6.Exit(0, Q)");

        }




        static void addUser()
        {
            DateTime now = DateTime.Now;
            int age = 0;
            clearPrint("----ADD USER----");
            string username = getText("username[Aa-Zz, 0-9]");
            string firstname = getText("first name");
            string lastname = getText("last name");
            string birthyear = getText("birth year");
            string phone = getText("phone");

            clearPrint("----CHECKING----");

            //validating input data
            if( validate(username,firstname,lastname,birthyear,phone))
            {
                age = now.Year - Convert.ToInt32(birthyear);
                if(age > 0)
                {
                    Console.WriteLine("everything is fine");
                    controller.insertToUsers(username, firstname, lastname, age, phone);
                }
                else
                {
                    Console.WriteLine("invalid age!");
                }
            }
            else
            {
                Console.WriteLine("----ERROR----\n" +
                                  "pls try again...");
            }


        }





        //=====================================
        //======== my custom functions ========
        //=====================================

        /// <summary>
        /// Read Key and Get Char
        /// </summary>
        /// <returns>KeyChar</returns>
        static char getKey()
        {
            char i = Console.ReadKey().KeyChar;
            return i;
        }

        /// <summary>
        /// yourText >> (user input)
        /// </summary>
        /// <param name="yourText">your text question</param>
        /// <returns>String</returns>
        static string getText(string yourText)
        {
            Console.Write(yourText+">> ");
            return Console.ReadLine(); ;
        }
        /// <summary>
        /// >> Read Line
        /// </summary>
        /// <returns>String</returns>
        static string getText()
        {
            Console.Write(">> ");
            return Console.ReadLine(); ;
        }

        /// <summary>
        /// clear screen and write line
        /// </summary>
        /// <param name="str">your text</param>
        static void clearPrint(string str)
        {
            Console.Clear();
            Console.WriteLine(str);
        }


        static bool validate(string username, string firstname, string lastname, string birthyear, string phone)
        {
            return (Regex.IsMatch(username, @"^[A-Za-z0-9_-]{3,20}$") &&
               Regex.IsMatch(firstname, @"^[A-Za-z]{3,20}$") &&
               Regex.IsMatch(lastname, @"^[A-Za-z]{3,20}$") &&
               Regex.IsMatch(birthyear, @"^[0-9]{4}$") &&
               Regex.IsMatch(phone, @"^[\+]?[(]?[0-9]{3}[)]?[0-9]{3}?[0-9]{4,6}$"));
        } 




    }


}
