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



//https://github.com/iso8859/learn-mongodb-by-example/tree/main/dotnet/01%20-%20Begin
namespace MongoConsoleApp

{

    public class Program
    {
        static void Main()
        {
            // new MongoBase();
            //new ListDataBases();


            //var collection = MongoBase.DB.GetCollection<Users>("users");
            // var userCount = collection.CountDocuments(Builders<Users>.Filter.Empty);


            //string password = Utils.GenerateNewPassword(0);

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