using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;
using MongoDB.Bson;

namespace MongoConsoleApp.Classes
{
    public class MongoBase
    {
        public static MongoClient Client { get; set; } = null;
        public static IMongoDatabase DB { get; set; } = null;
        public string ConnectionString = "mongodb+srv://yourHero:yourHero@wpfcluster.jbm7ovt.mongodb.net/?retryWrites=true&w=majority&appName=WPFCluster";

        public MongoBase()
        {
            Console.WriteLine("Connecting to DB...");
            CreateConnection();
            SetDataBase();
        }

        private void SetDataBase()
        {
            if (Client is MongoClient)
            {
                DB = Client.GetDatabase("sample_mflix");
            }
        }

        private void CreateConnection()
        {
            // catch some issues 
            try
            {
                Client = new MongoClient(ConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Problem.", ex.Message);

            }

        }

    }
}


