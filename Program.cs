﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Dse;


namespace UsersList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DBControll controller = new DBControll();


               
                //   username,    firstname,  lastname,   age,    phone
                List<string> user = new List<string>();
                List<List<string>> usersList = new List<List<string>>();
             
                

        bool exit = false;
            while (exit != true)
            {
                //clear screen and show main menu
                showMainMenu();
                //controller.insertToUsers("TanblanKhan", "Jamshid", "Jamshidi", 30, "09203040555");
                foreach (var R2ow in controller.showAllUsers())
                {
                    Console.WriteLine(R2ow+":::\n");
                    foreach (var R3ow in R2ow)
                        Console.WriteLine(R3ow+"\n");
                }
                
                //get user choice
                switch (getKey())
                {
                    case '1': //add user
                    case 'a':
                    case 'A':

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
                        "1.Add user(a)\n" +
                        "2.Search user((s)\n" +
                        "3.Delete user\n" +
                        "4.Show users\n" +
                        "5.Save users to a file\n" +
                        "6.Load users from a file\n" +
                        "7.Exit(0, Q)");

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


        ///static void 




    }


}