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
        private const char splitUsers = ',';
        private const char splitItems = ':';
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
                ShowMainMenu();
                
                
                //get user choice
                switch (GetKey())
                {
                    case '1': //add user
                    case 'a':
                    case 'A':
                        AddUser();
                        GetKey();
                        break;


                    case '2': //search user
                    case 's':
                    case 'S':
                        
                        SearchUser();
                        GetKey();
                        break;


                    case '3': //delete user
                        DeleteUser();
                        break;


                    case '4': //show users
                        ShowUsers();
                        break;


                    case '5': //save users
                        SaveUsers();
                        break;


                    case '6': //load users
                        LoadUsers();
                        break;

                        

                    case '0'://exit
                    case 'q':
                    case 'Q':
                    case '7':
                        exit = true;

                        ClearPrint("Bye!");

                        break;


                    default:
                        ClearPrint("Wrong choice!");
                        GetKey();
                        break;

                }


            }



            


        }


        


        /// <summary>
        /// clear screen and print main menu
        /// </summary>
        static void ShowMainMenu()
        {
            ClearPrint("----MENU----\n" +
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
        static void ShowSearchMenu()
        {
            ClearPrint("----SEARCH----\n" +
                        "1.by Username(U)\n" +
                        "2.by First Name(F)\n" +
                        "3.by Last Name(L)\n" +
                        "4.by Age(A)\n" +
                        "5.by Phone(P)\n" +
                        "6.Exit(0, Q)");

        }

        static void SearchUser()
        {
            bool exit = false;
            string input = "";
            while (!exit)
            {
                ShowSearchMenu();
                switch (GetKey())
                {
                    case 'u':
                    case 'U':
                    case '1':// BY Username
                        input = GetText("username");
                        if (ValidateUsername(input))
                        {
                            ClearPrint("----RESULT----");
                            int counter = 0;
                            foreach(var i in controller.FindByUsername(input))
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
                        GetKey();
                        break;
                    case 'F':
                    case 'f':
                    case '2':// BY First Name
                        input = GetText("First Name");
                        if (ValidateName(input))
                        {
                            ClearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.FindByFirstname(input))
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
                        GetKey();
                        break;
                    case 'l':
                    case 'L':
                    case '3':// BY Last Name
                        input = GetText("Last Name");
                        if (ValidateName(input))
                        {
                            ClearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.FindByLastname(input))
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
                        GetKey();
                        break;
                    case 'A':
                    case 'a':
                    case '4':// BY Age
                        input = GetText("Age");
                        if (ValidateAge(input))
                        {
                            ClearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.FindByAge(input))
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
                        GetKey();
                        break;
                    case 'p':
                    case 'P':
                    case '5':// BY Phone
                        input = GetText("Phone");
                        if (ValidatePhone(input))
                        {
                            ClearPrint("----RESULT----");
                            int counter = 0;
                            foreach (var i in controller.FindByPhone(input))
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
                        GetKey();
                        break;
                    case 'Q':
                    case 'q':
                    case '0':
                    case '6':// Exit
                        exit=true;
                        break;
                    default:
                        ClearPrint("Wrong choice!");
                        GetKey();
                        break;
                }
                
            }
            

        }

        static void DeleteUser()
        {
            ClearPrint("----DELETE USER----");
            string username = GetText("username");
            ClearPrint("----CHECKING----");
            if (IsUserExistByUsername(username) == 1) // if user exist
            {
                Console.WriteLine(" r u sure? (Y/N)");
                char x = GetKey();
                Console.WriteLine("");
                if (x == 'y' || x == 'Y')
                {
                    controller.DeleteUser(username);
                    
                }
                else
                {
                    Console.WriteLine("failed!");
                }
                
            }
            else if (IsUserExistByUsername(username) == 0) // if user doesnt exist
            {
                Console.WriteLine("this user doesnt exist!");
            }
            else // (-1) bad input
            {
                Console.WriteLine("----ERROR----\n" +
                                    "invalid username...");
            }
            GetKey();
        }

        static void AddUser()
        {
            DateTime now = DateTime.Now;
            int age = 0;
            ClearPrint("----ADD USER----");
            string username = GetText("username[Aa-Zz, 0-9]");
            string firstname = GetText("first name");
            string lastname = GetText("last name");
            string birthyear = GetText("birth year");
            string phone = GetText("phone");

            ClearPrint("----CHECKING----");
            //validating input data
            if (IsUserExistByUsername(username) == 1)
            {
                Console.WriteLine("----ERROR----");
                Console.WriteLine("a user with this username is already exist");
            }
            else if(Validate(username,firstname,lastname,birthyear,phone))
            {
                age = now.Year - Convert.ToInt32(birthyear);
                if(age > 0)
                {
                    Console.WriteLine("everything is fine");
                    controller.InsertToUsers(username, firstname, lastname, age, phone);
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
        static void ShowShowUsersMenu()
        {
            ClearPrint("----SHOW USERS----\n" +
                        "1.sort by Username(U)\n" +
                        "2.sort by First Name(F)\n" +
                        "3.sort by Last Name(L)\n" +
                        "4.sort by Age(A)\n" +
                        "5.sort by Phone(P)\n" +
                        "6.default(D)\n" +
                        "7.Exit(0, Q)");

        }
        static void ShowUsers()
        {
            bool exit = false;
            while (!exit)
            {
                ShowShowUsersMenu();
                switch (GetKey())
                {
                    case 'u':
                    case 'U':
                    case '1'://sort BY Username
                        SortUsersByUsername();
                        GetKey();
                        break;
                    case 'f':
                    case 'F':
                    case '2'://sort BY First name
                        SortUsersByFirstName();

                        GetKey();
                        break;
                    case 'l':
                    case 'L':
                    case '3'://sort BY Last name
                        SortUsersByLastName();

                        GetKey();
                        break;
                    case 'a':
                    case 'A':
                    case '4'://sort BY Age
                        SortUsersByAge();

                        GetKey();
                        break;
                    case 'p':
                    case 'P':
                    case '5'://sort BY Phone
                        SortUsersByPhone();

                        GetKey();
                        break;
                    case 'd':
                    case 'D':
                    case '6'://show default
                        ShowUsersByDefault();

                        GetKey();
                        break;
                    case 'Q':
                    case 'q':
                    case '0':
                    case '7':// Exit
                        exit = true;
                        break;
                    default:
                        ClearPrint("Wrong choice!");
                        GetKey();
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
        static char GetKey()
        {
            char i = Console.ReadKey().KeyChar;
            return i;
        }

        /// <summary>
        /// yourText >> (user input)
        /// </summary>
        /// <param name="yourText">your text question</param>
        /// <returns>String</returns>
        static string GetText(string yourText)
        {
            Console.Write("\n"+yourText+">> ");
            return Console.ReadLine(); ;
        }
        /// <summary>
        /// >> Read Line
        /// </summary>
        /// <returns>String</returns>
        static string GetText()
        {
            Console.Write(">> ");
            return Console.ReadLine(); ;
        }

        /// <summary>
        /// clear screen and write line
        /// </summary>
        /// <param name="str">your text</param>
        static void ClearPrint(string str)
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
        static bool Validate(string username, string firstname, string lastname, string birthyear, string phone)
        {
            return (ValidateUsername(username)  &&
                    ValidateName(firstname)     &&
                    ValidateName(lastname)      &&
                    ValidateBirthYear(birthyear)&&
                    ValidatePhone(phone) );
        }
        static bool ValidateUsername(string username)
        {
            return Regex.IsMatch(username, @"^[A-Za-z0-9_-]{3,20}$");
        }
        static bool ValidateName(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z]{3,20}$");
        }
        static bool ValidateBirthYear(string birthyear)
        {
            return Regex.IsMatch(birthyear, @"^[0-9]{4}$");
        }
        static bool ValidateAge(string age)
        {
            return Regex.IsMatch(age, @"^[0-9]{1,3}$");
        }
        static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^[\+]?[(]?[0-9]{3}[)]?[0-9]{3}?[0-9]{4,6}$");
        }
        /// <summary>
        /// check user exist or not
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>1=exist, 0=not exist, -1=invalid username</returns>
        static int IsUserExistByUsername(string username)
        {
            if (ValidateUsername(username))
            {
                foreach (var i in controller.FindByUsername(username))
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

        static bool ValidateFileName(string filename)
        {
            return Regex.IsMatch(filename, @"^[A-Za-z0-9.-]{3,20}$");
        }



        //=====================================//
        //=========== SHOW USERS ==============//
        //=====================================//

        static void ShowUsersByDefault()
        {
            Dse.RowSet rows = controller.GetAllUsers();
            ClearPrint("----RESULT----");
            
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
        static void ShowItemsByList(List<List<string>> list)
        {
            
            ClearPrint("----RESULT----");
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

        static void SortUsersByUsername()
        {
            //just usernames ->sort
            List<string> sort = new List<string>();

            //get all usernames and put to sort list
            foreach (var i in controller.GetAllUsernames())
                foreach (string name in i)
                    sort.Add(name);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            ClearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.FindByUsername(item))
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
            //GetKey();
            //////////////////


        }

        static void SortUsersByFirstName()
        {
            //just FirstName ->sort
            List<string> sort = new List<string>();

            //get all FirstName and put to sort list
            foreach (var i in controller.GetAllNames())
                foreach (string name in i)
                    sort.Add(name);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            ClearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.FindByFirstname(item))
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
            //GetKey();
            //////////////////


        }

        static void SortUsersByLastName()
        {
            //just LastNames ->sort
            List<string> sort = new List<string>();

            //get all LastNames and put to sort list
            foreach (var i in controller.GetAllLastNames())
                foreach (string lname in i)
                    sort.Add(lname);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            ClearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.FindByLastname(item))
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
            //GetKey();
            //////////////////


        }

        static void SortUsersByAge()
        {
            //just Ages ->sort
            List<string> sort = new List<string>();

            //get all Ages and put to sort list
            foreach (var i in controller.GetAllAges())
                foreach (int name in i)
                    sort.Add(name.ToString());


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            ClearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.FindByAge(item))
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
            //GetKey();
            //////////////////


        }

        static void SortUsersByPhone()
        {
            //just Phones ->sort
            List<string> sort = new List<string>();

            //get all Phones and put to sort list
            foreach (var i in controller.GetAllPhones())
                foreach (string phone in i)
                    sort.Add(phone);


            // Sorting sort list
            sort = sort.Distinct().ToList();
            sort.Sort();

            ClearPrint("----RESULT----");

            int counter = 0;
            foreach (var item in sort)
            {
                foreach (var i in controller.FindByPhone(item))
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
            //GetKey();
            //////////////////

        }


        //=====================================//
        //========= SAVE/LOAD USERS ===========//
        //=====================================//

        //save with ":"(items) and ","(users)
        static void SaveUsers()
        {
            //just usernames ->sort
            List<string> sort = new List<string>();

            //get all usernames and put to sort list
            foreach (var i in controller.GetAllUsernames())
                foreach (string name in i)
                    sort.Add(name);


            // Sorting sort list
            sort.Sort();

            ClearPrint("----SAVE----");

            string filename = GetText("file name(default: test.txt)[A-Z a-z .]");
            Console.WriteLine((ValidateFileName(filename)) ? "your file name is ok" : "your file name is invalid... default name: test.txt");
            string data = "";
            string forColon = "";
            try
            {
                FileControll file = new FileControll(@"D:\" + ((ValidateFileName(filename)) ? filename : "test.txt"));
                if (!file.ExistFile())
                {
                    foreach (var item in sort)
                    {
                        foreach (var i in controller.FindByUsername(item))
                        {
                            forColon = "";
                            data = "";
                            foreach (var j in i)
                            {
                                data += forColon + j.ToString();
                                forColon = ":";
                            }
                            file.AddText(data+",");
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
                GetKey();
            }

            


            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //GetKey();
            //////////////////


        }
        
         static void LoadUsers()
        {
            List<string> list = new List<string>();
            List<string> items = new List<string>();

            ClearPrint("----LOAD----");

            string filename = GetText("file name(default: test.txt)[A-Z a-z .]");

            Console.WriteLine((ValidateFileName(filename)) ? "your file name is ok" : "your file name is invalid... default name: test.txt");

            try
            {
                FileControll file = new FileControll(@"D:\" + ((ValidateFileName(filename)) ? filename : "test.txt"));
                if (file.ExistFile())
                {
                    list = file.ReadFile().Split(splitUsers).ToList();
                    foreach (string item in list)
                    {
                        if (item != "") //=> item == "username:fname:lname:age:phone"
                        {
                            items = item.Split(splitItems).ToList();
                            if (IsUserExistByUsername(items[0].ToString())==0)
                            {
                                // uname,fname,lname,age,phone
                                controller.InsertToUsers(
                                                items[0],
                                                items[1],
                                                items[2],
                                                Convert.ToInt32(items[3]),
                                                items[4]);
                                Console.WriteLine(items[0].ToString() + " added");
                            }
                            else
                            {
                                Console.WriteLine("error(user name)" + items[0].ToString());
                            }
                        }
                    }
                        

                            
                }
                else
                {

                    Console.WriteLine("\nthis file doesnt exist...\n" +
                                    "pls try again and test another file name.\n" +
                                    "press any key to exit...");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n error \n" + e.Message);
            }
            finally
            {
                GetKey();
            }

            


            /*string x = "Abbas:abbas:abbasi:23:09334443322,ahmad:ahmadi:ahamdidi:20:09883334455,Danial:Danial:DanialZadeh:18:09112342233,Tohid:Tohid:Eghdami:19:093078227788,zahra:zahra:zzzzz:23:09112223322,zoheyir:zohey:zoheyrzadeh:22:09887776655,";

            
            list = x.Split(splitUsers).ToList();
            foreach (string item in list)
                if (item) ;*/

            //////////////////
            //debug and test//
            /*foreach (var i in sort)
                Console.WriteLine(i);*/
            //GetKey();
            //////////////////


        }

    }
}
