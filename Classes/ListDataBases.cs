using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsoleApp.Classes
{
    public class ListDataBases
    {
        public ListDataBases()
        {

            if (MongoBase.Client is MongoClient)
            {
                List<string> databases = MongoBase.Client.ListDatabaseNames().ToList();

                foreach (string database in databases)

                {
                    Console.WriteLine(database);
                }
            }
        }
    }
}
