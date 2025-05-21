using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoConsoleApp.Classes;
using MongoDB.Driver.Linq;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;


namespace MongoConsoleApp

{

    public class Program
    {
        static void Main()
        {
            new MongoBase();
            IMongoCollection<Users> collection = MongoBase.DB.GetCollection<Users>("users");

            // complexity 8 = 256,   14 = 16,000 , 31 = 2, 147,483,646 iterations
            Console.WriteLine("Whats your password ?");
            string userPassword = Console.ReadLine();
            string hashed = BCrypt.Net.BCrypt.EnhancedHashPassword(userPassword, 14);

            Console.WriteLine($"Will write {hashed} to the database.");

            while (true)
            {
                Console.WriteLine("Whats your password ?");
                string otherPassword = Console.ReadLine();

                if (string.IsNullOrEmpty(otherPassword))
                {
                    Environment.Exit(0);
                }

                Boolean resultAsBoolean = BCrypt.Net.BCrypt.EnhancedVerify(otherPassword, hashed);


                string message = (resultAsBoolean == true) ? "Success, Logged are now logged-in." : "We do not recognise that Login.";

                if (resultAsBoolean == true)
                {
                    Users temp = new Users("test", "blah@123.com", hashed);
                    collection.InsertOne(temp);
                }

                Console.WriteLine(message);
            }



        }
    }

}



//public override Paging<Website> GetList<TFilter>(IFilter<TFilter> filter)
//{
//    WebsiteFilter websiteFilter = filter as WebsiteFilter;

//    var builder = Builders<Website>.Filter;
//    FilterDefinition<Website> queryFilter = builder.Empty;

//    if (!string.IsNullOrEmpty(websiteFilter.name))
//    {
//        queryFilter = queryFilter & builder.Regex($"name", new BsonRegularExpression($".*{websiteFilter.name}.*", "i"));
//    }

//    SortDefinition<Website> sort = Builders<Website>.Sort.Ascending(x => x.Id);

//    return new Paging<Website>(this.Collection, websiteFilter.page, queryFilter, sort, websiteFilter.per_page);
//}