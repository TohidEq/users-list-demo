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
            //List<string> sort = new List<string>();
            //List<List<string>> usersList = new List<List<string>>();
            

            bool exit = false;
            while (!exit)
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
                        
                        searchUser();
                        getKey();
                        break;


                    case '3': //delete user
                        deleteUser();
                        break;


                    case '4': //show users
                        showUsers();
                        break;


                    case '5': //save users
                        saveUsers();
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
                        getKey();
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
                        "4.Show users/Sort\n" +
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

        static void searchUser()
        {
            bool exit = false;
            string input = "";
            while (!exit)
            {
                showSearchMenu();
                switch (getKey())
                {
                    case 'u':
                    case 'U':
                    case '1':// BY Username
                        input = getText("username");
                        if (validateUsername(input))
                        {
                            clearPrint("----RESULT----");
                            int counter = 0;
                            foreach(var i in controller.findByUsername(input))
                            {
                                if (counter == 0)
                                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone");
                                counter++;
                                Console.Write("\n" + counter + ". ");
                                foreach (var j in i)
                                {
                                    Console.Write(j + "\t");
                                }

                            }
                            Console.WriteLine("\n" + counter +" user found");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                        getKey();
                        break;
                    case 'F':
                    case 'f':
                    case '2':// BY First Name
                        input = getText("First Name");
                        if (validateName(input))
                        {
                            clearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.findByFirstname(input))
                            {
                                if (counter == 0)
                                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone");
                                counter++;
                                Console.Write("\n" + counter + ". ");
                                foreach (var j in i)
                                {
                                    Console.Write(j + "\t");
                                }

                            }
                            Console.WriteLine("\n" + counter + " user found");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                        getKey();
                        break;
                    case 'l':
                    case 'L':
                    case '3':// BY Last Name
                        input = getText("Last Name");
                        if (validateName(input))
                        {
                            clearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.findByLastname(input))
                            {
                                if (counter == 0)
                                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone");
                                counter++;
                                Console.Write("\n" + counter + ". ");
                                foreach (var j in i)
                                {
                                    Console.Write(j + "\t");
                                }

                            }
                            Console.WriteLine("\n"+counter + " user found");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                        getKey();
                        break;
                    case 'A':
                    case 'a':
                    case '4':// BY Age
                        input = getText("Age");
                        if (validateAge(input))
                        {
                            clearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.findByAge(input))
                            {
                                if(counter==0)
                                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone");
                                counter++;
                                Console.Write("\n" + counter + ". ");
                                foreach (var j in i)
                                {
                                    Console.Write(j + "\t");
                                }

                            }
                            Console.WriteLine("\n" + counter + " user found");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                        getKey();
                        break;
                    case 'p':
                    case 'P':
                    case '5':// BY Phone
                        input = getText("Phone");
                        if (validatePhone(input))
                        {
                            clearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.findByPhone(input))
                            {
                                if (counter == 0)
                                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone");
                                counter++;
                                Console.Write("\n" + counter + ". ");
                                foreach (var j in i)
                                {
                                    Console.Write(j + "\t");
                                }

                            }
                            Console.WriteLine("\n" + counter + " user found");
                        }
                        else
                        {
                            Console.WriteLine("invalid");
                        }
                        getKey();
                        break;
                    case 'Q':
                    case 'q':
                    case '0':
                    case '6':// Exit
                        exit=true;
                        break;
                    default:
                        clearPrint("Wrong choice!");
                        getKey();
                        break;
                }
                
            }
            

        }

        static void deleteUser()
        {
            clearPrint("----DELETE USER----");
            string username = getText("username");
            clearPrint("----CHECKING----");
            if (isUserExistByUsername(username) == 1) // if user exist
            {
                Console.WriteLine(" r u sure? (Y/N)");
                char x = getKey();
                Console.WriteLine("");
                if (x == 'y' || x == 'Y')
                {
                    controller.deleteUser(username);
                    
                }
                else
                {
                    Console.WriteLine("failed!");
                }
                
            }
            else if (isUserExistByUsername(username) == 0) // if user doesnt exist
            {
                Console.WriteLine("this user doesnt exist!");
            }
            else // (-1) bad input
            {
                Console.WriteLine("----ERROR----\n" +
                                    "invalid username...");
            }
            getKey();
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
            if (isUserExistByUsername(username) == 1)
            {
                Console.WriteLine("----ERROR----");
                Console.WriteLine("a user with this username is already exist");
            }
            else if(validate(username,firstname,lastname,birthyear,phone))
            {
                age = now.Year - Convert.ToInt32(birthyear);
                if(age > 0)
                {
                    Console.WriteLine("everything is fine");
                    controller.insertToUsers(username, firstname, lastname, age, phone);
                    Console.WriteLine("successful!");
                }
                else
                {
                    Console.WriteLine("invalid age!");
                }
            }else
            {
                Console.WriteLine("----ERROR----\n" +
                                    "pls try again...");
            }
            


        }




        /// <summary>
        /// clear screen and print show users menu
        /// </summary>
        static void showShowUsersMenu()
        {
            clearPrint("----SHOW USERS----\n" +
                        "1.sort by Username(U)\n" +
                        "2.sort by First Name(F)\n" +
                        "3.sort by Last Name(L)\n" +
                        "4.sort by Age(A)\n" +
                        "5.sort by Phone(P)\n" +
                        "6.default(D)\n" +
                        "7.Exit(0, Q)");

        }
        static void showUsers()
        {
            bool exit = false;
            while (!exit)
            {
                showShowUsersMenu();
                switch (getKey())
                {
                    case 'u':
                    case 'U':
                    case '1'://sort BY Username
                        sortUsersByUsername();
                        getKey();
                        break;
                    case 'f':
                    case 'F':
                    case '2'://sort BY First name
                        sortUsersByFirstName();

                        getKey();
                        break;
                    case 'l':
                    case 'L':
                    case '3'://sort BY Last name
                        sortUsersByLastName();

                        getKey();
                        break;
                    case 'a':
                    case 'A':
                    case '4'://sort BY Age
                        sortUsersByAge();

                        getKey();
                        break;
                    case 'p':
                    case 'P':
                    case '5'://sort BY Phone
                        sortUsersByPhone();

                        getKey();
                        break;
                    case 'd':
                    case 'D':
                    case '6'://show default
                        showUsersByDefault();

                        getKey();
                        break;
                    case 'Q':
                    case 'q':
                    case '0':
                    case '7':// Exit
                        exit = true;
                        break;
                    default:
                        clearPrint("Wrong choice!");
                        getKey();
                        break;
                }
            } 
        }



        //=====================================//
        //======== my custom functions ========//
        //=====================================//

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
            Console.Write("\n"+yourText+">> ");
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



        //=====================================//
        //=========== VALIDATIONS =============//
        //=====================================//

        /// <summary>
        /// Validation
        /// </summary>
        /// <returns>bool</returns>
        static bool validate(string username, string firstname, string lastname, string birthyear, string phone)
        {
            return (validateUsername(username)  &&
                    validateName(firstname)     &&
                    validateName(lastname)      &&
                    validateBirthYear(birthyear)&&
                    validatePhone(phone) );
        }
        static bool validateUsername(string username)
        {
            return Regex.IsMatch(username, @"^[A-Za-z0-9_-]{3,20}$");
        }
        static bool validateName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z]{3,20}$");
        }
        static bool validateBirthYear(string birthyear)
        {
            return Regex.IsMatch(birthyear, @"^[0-9]{4}$");
        }
        static bool validateAge(string age)
        {
            return Regex.IsMatch(age, @"^[0-9]{1,3}$");
        }
        static bool validatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^[\+]?[(]?[0-9]{3}[)]?[0-9]{3}?[0-9]{4,6}$");
        }
        /// <summary>
        /// check user exist or not
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>1=exist, 0=not exist, -1=invalid username</returns>
        static int isUserExistByUsername(string username)
        {
            if (validateUsername(username))
            {
                foreach (var i in controller.findByUsername(username))
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }

        static bool validateFileName(string filename)
        {
            return Regex.IsMatch(filename, @"^[A-Za-z0-9.-]{3,20}$");
        }



        //=====================================//
        //=========== SHOW USERS ==============//
        //=====================================//

        static void showUsersByDefault()
        {
            Dse.RowSet rows = controller.getAllUsers();
            clearPrint("----RESULT----");
            
            int counter = 0;
            foreach (var i in rows)
            {
                if (counter == 0)
                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone \t(default cassandra sort by userid(uuid...))");
                counter++;
                Console.Write("\n" + counter + ". ");
                foreach (var j in i)
                {
                    Console.Write(j + "\t");
                }

            }
            
            Console.WriteLine("\n" + counter + " user found");
        }
        static void showItemsByList(List<List<string>> list)
        {
            
            clearPrint("----RESULT----");
            list.Distinct();
            int counter = 0;
            foreach (var i in list)
            {
                if (counter == 0)
                    Console.WriteLine("uName \tfName \tlName \tAge \tPhone");
                counter++;
                Console.Write("\n" + counter + ". ");
                foreach (var j in i)
                {
                    Console.Write(j + "\t");
                }

            }

            Console.WriteLine("\n" + counter + " user found");
        }

        static void sortUsersByUsername()
        {
            //just usernames ->sort
            List<string> sort = new List<string>();

            //get all usernames and put to sort list
            foreach (var i in controller.getAllUsernames())
                foreach (string name in i)
                    sort.Add(name);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            clearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.findByUsername(item))
                {
                    if (counter == 0)
                        Console.WriteLine("uName* \tfName \tlName \tAge \tPhone");
                    counter++;
                    Console.Write("\n" + counter + ". ");
                    foreach (var j in i)
                    {
                        Console.Write(j + "\t");
                    }

                }
            }


            Console.WriteLine("\n" + counter + " user found");


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //getKey();
            //////////////////


        }

        static void sortUsersByFirstName()
        {
            //just FirstName ->sort
            List<string> sort = new List<string>();

            //get all FirstName and put to sort list
            foreach (var i in controller.getAllNames())
                foreach (string name in i)
                    sort.Add(name);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            clearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.findByFirstname(item))
                {
                    if (counter == 0)
                        Console.WriteLine("uName \tfName* \tlName \tAge \tPhone");
                    counter++;
                    Console.Write("\n" + counter + ". ");
                    foreach (var j in i)
                    {
                        Console.Write(j + "\t");
                    }

                }
            }


            Console.WriteLine("\n" + counter + " user found");


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //getKey();
            //////////////////


        }

        static void sortUsersByLastName()
        {
            //just LastNames ->sort
            List<string> sort = new List<string>();

            //get all LastNames and put to sort list
            foreach (var i in controller.getAllLastNames())
                foreach (string lname in i)
                    sort.Add(lname);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            clearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.findByLastname(item))
                {
                    if (counter == 0)
                        Console.WriteLine("uName \tfName \tlName* \tAge \tPhone");
                    counter++;
                    Console.Write("\n" + counter + ". ");
                    foreach (var j in i)
                    {
                        Console.Write(j + "\t");
                    }

                }
            }


            Console.WriteLine("\n" + counter + " user found");


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //getKey();
            //////////////////


        }

        static void sortUsersByAge()
        {
            //just Ages ->sort
            List<string> sort = new List<string>();

            //get all Ages and put to sort list
            foreach (var i in controller.getAllAges())
                foreach (int name in i)
                    sort.Add(name.ToString());


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            clearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.findByAge(item))
                {
                    if (counter == 0)
                        Console.WriteLine("uName \tfName \tlName \tAge* \tPhone");
                    counter++;
                    Console.Write("\n" + counter + ". ");
                    foreach (var j in i)
                    {
                        Console.Write(j + "\t");
                    }

                }
            }


            Console.WriteLine("\n" + counter + " user found");


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //getKey();
            //////////////////


        }

        static void sortUsersByPhone()
        {
            //just Phones ->sort
            List<string> sort = new List<string>();

            //get all Phones and put to sort list
            foreach (var i in controller.getAllPhones())
                foreach (string phone in i)
                    sort.Add(phone);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            clearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.findByPhone(item))
                {
                    if (counter == 0)
                        Console.WriteLine("uName \tfName \tlName \tAge \tPhone*");
                    counter++;
                    Console.Write("\n" + counter + ". ");
                    foreach (var j in i)
                    {
                        Console.Write(j + "\t");
                    }

                }
            }


            Console.WriteLine("\n" + counter + " user found");


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //getKey();
            //////////////////

        }


        //=====================================//
        //========= SAVE/LOAD USERS ===========//
        //=====================================//

        static void saveUsers()
        {
            //just usernames ->sort
            List<string> sort = new List<string>();

            //get all usernames and put to sort list
            foreach (var i in controller.getAllUsernames())
                foreach (string name in i)
                    sort.Add(name);


            // Sorting sort list
            sort.Sort();

            clearPrint("----SAVE----");

            string filename = getText("file name(default: test.txt)[A-Z a-z .]");
            Console.WriteLine((validateFileName(filename)) ? "your file name is ok" : "your file name is invalid... default name: test.txt");
            string data = "";
            string forColon = "";
            try
            {
                FileControll file = new FileControll(@"D:\" + ((validateFileName(filename)) ? filename : "test.txt"));
                if (!file.existFile())
                {
                    foreach (var item in sort)
                    {
                        foreach (var i in controller.findByUsername(item))
                        {
                            forColon = "";
                            data = "";
                            foreach (var j in i)
                            {
                                data += forColon + j.ToString();
                                forColon = ":";
                            }
                            file.addLine(data);
                        }
                    }


                    Console.WriteLine("\n saved");
                }
                else
                {

                    Console.WriteLine("\n this file exist...\n" +
                                    "pls try again and test another file name.\n" +
                                    "press any key to exit...");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("\n error \n"+e.Message);
            }
            finally
            {
                getKey();
            }

            


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //getKey();
            //////////////////


        }

    }
}
