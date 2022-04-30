using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Dse;

namespace UsersList
{
    internal class DBControll
    {
        private IDseSession session;

        /// <summary>
        /// connect to localhost->keyspace_users_csharp
        /// </summary>
        public DBControll()
        {
            session = DseCluster.Builder()
            .AddContactPoint("localhost")
            .Build().Connect("keyspace_users_csharp");

        }

        /// <summary>
        /// connect to custom db
        /// </summary>
        /// <param name="ContactPoint">Contact Point</param>
        /// <param name="KeyspaceName">Keyspace Name</param>
        public DBControll(string ContactPoint, String KeyspaceName)
        {
            session = DseCluster.Builder()
            .AddContactPoint(ContactPoint)
            .Build().Connect(KeyspaceName);
        }

        /// <summary>
        /// Add a user to users table
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="firstname">first name</param>
        /// <param name="lastname">last name</param>
        /// <param name="age">age</param>
        /// <param name="phone">phone</param>
        public void InsertToUsers(string username,string firstname, string lastname, int age, string phone)
        {
            session.Execute("INSERT INTO users (id,username,firstname,lastname,age,phone) VALUES " +
                "(uuid(), '" 
                + username +    "', '"
                + firstname +   "', '"
                + lastname +    "',  "
                + age +         " , '"
                + phone +       "')");
        }

        /// <summary>
        /// update user's info
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="firstname"> first name</param>
        /// <param name="lastname">last name</param>
        /// <param name="age">age</param>
        /// <param name="phone">phone number</param>
        public void UpdateUser(string username, string firstname, string lastname, int age, string phone)
        {
            session.Execute("UPDATE users SET " +
                            "firstname= '" +    firstname   + "',"  +
                            "lastname= '" +     lastname    + "',"  +
                            "age= " +           age         + ","   +
                            "phone= '" +        phone       + "'"   +
                            "WHERE username='" +username    + "'"   );

        }


        /// <summary>
        /// Delete a user by username from users table
        /// </summary>
        /// <param name="username">username</param>
        public void DeleteUser(string username)
        {
            foreach (var i in session.Execute("select id from users where username='" + username + "' allow filtering"))
                foreach (var id in i)
                {
                    session.Execute("DELETE FROM users WHERE id = " + id + "");
                    Console.WriteLine("\nsuccessful!");
                }
            
        }

        // DELETE ALL ROWS
        public void DeleteUsersAllRows()
        {
            session.Execute("TRUNCATE users");
        }

        
        



        //==========================//
        //=== start FIND methods ===//
        //======== & get ===========//
        //==========================//

        /// <summary>
        /// get all Usernames
        /// </summary>
        /// <returns> Dse.RowSet </returns>
        public Dse.RowSet GetAllUsernames()
        {
            return session.Execute("select username from users");
        }
        public Dse.RowSet GetAllNames()
        {
            return session.Execute("select firstname from users");
        }
        public Dse.RowSet GetAllLastNames()
        {
            return session.Execute("select lastname from users");
        }
        public Dse.RowSet GetAllAges()
        {
            return session.Execute("select age from users");
        }
        public Dse.RowSet GetAllPhones()
        {
            return session.Execute("select phone from users");
        }
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns> Dse.RowSet </returns>
        public Dse.RowSet GetAllUsers()
        {
            return session.Execute("select username,firstname,lastname,age,phone from users");
        }


        public List<string> GetOneUserRowInListByUsername(string username)
        {
            List<string> rowString = new List<string>();
            foreach(Dse.Row i in FindByUsername(username))
                foreach(var value in i)
                    rowString.Add(value.ToString());
            return rowString;
        }


        //FindByUsername
        public Dse.RowSet FindByUsername(string username)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where username='"+username+"' allow filtering");
        }
        //findByFirstname
        public Dse.RowSet FindByFirstname(string firstname)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where firstname='" + firstname + "' allow filtering");
        }
        //findByLastname
        public Dse.RowSet FindByLastname(string lastname)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where lastname='" + lastname + "' allow filtering");
        }
        //findByAge
        public Dse.RowSet FindByAge(string age)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where age=" + age + " allow filtering");
        }
        //findByPhone
        public Dse.RowSet FindByPhone(string phone)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where phone='" + phone + "' allow filtering");
        }
        //getIdByUsername
        public string GetIdByUsername(string username)
        {

            foreach (var i in session.Execute("select id from users where username='" + username + "' allow filtering"))
                foreach (string j in i)
                {
                    
                    return(j);
                }
            return "0";
        }

        //==========================//
        //==== end FIND methods ====//
        //==========================//


    }
}

