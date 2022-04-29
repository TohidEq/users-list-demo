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
    }
}



/*var cluster = DseCluster.Builder()
            .AddContactPoint("localhost")
            .Build();

var session = cluster.Connect();

var row = session.Execute("select * from system.local");
foreach (var R2ow in row) 
{
    foreach(var R3ow in R2ow)
    Console.WriteLine(R3ow);
}*/
