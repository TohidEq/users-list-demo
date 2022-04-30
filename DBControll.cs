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
        public void insertToUsers(string username,string firstname, string lastname, int age, string phone)
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
        public void deleteUser(string username)
        {
            session.Execute("DELETE * FROM users WHERE username = '" + username + "'");
        }

        // DELETE ALL ROWS
        private void DeleteUsersRows()
        {
            session.Execute("TRUNCATE users");
        }

        
        



        //==========================//
        //=== start FIND methods ===//
        //======== & get ===========//
        //==========================//

        /// <summary>
        /// get all userNames
        /// </summary>
        /// <returns> Dse.RowSet </returns>
        public Dse.RowSet getAllUserNames()
        {
            return session.Execute("select username from users");
        }

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns> Dse.RowSet </returns>
        public Dse.RowSet getAllUsers()
        {
            return session.Execute("select username,firstname,lastname,age,phone from users");
        }

        //findByUsername
        public Dse.RowSet findByUsername(string username)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where username='"+username+"' allow filtering");
        }
        //findByFirstname
        public Dse.RowSet findByFirstname(string firstname)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where firstname='" + firstname + "' allow filtering");
        }
        //findByLastname
        public Dse.RowSet findByLastname(string lastname)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where lastname='" + lastname + "' allow filtering");
        }
        //findByAge
        public Dse.RowSet findByAge(string age)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where age=" + age + " allow filtering");
        }
        //findByPhone
        public Dse.RowSet findByPhone(string phone)
        {
            return session.Execute("select username,firstname,lastname,age,phone from users where phone='" + phone + "' allow filtering");
        }

        //==========================//
        //==== end FIND methods ====//
        //==========================//


    }
}

