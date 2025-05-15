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
            new MongoBase();
            new ListDataBases();


            var collection = MongoBase.DB.GetCollection<Users>("users");


            var userCount = collection.CountDocuments(Builders<Users>.Filter.Empty);



            var filter = Builders<Users>.Filter.Eq(g => g.Name, "Cersei Lannister");

            // var filter = Builders<Users>.Filter.Eq(g => g.Name, new Regex(@" /cersei Lannister/i"));

            //var filter2 = Builders<Users>.Filter.In(g => g.Email, new[] { "iain_glen@gameofthron.es", "example2@example.com" });
            //var results = _guitarsCollection.Find(g => g.EstablishedYear > 1985).ToList();
            // Fix for CS1501: The 'In' method requires two arguments: the field to filter on and a collection of values.
            // var filter = Builders<Users>.Filter.In(g => g.Email, new[] { "example1@example.com", "example2@example.com" });


            // case insense
            // var regexFilter = Regex.Escape(filter);
            //var bsonRegex = new BsonRegularExpression(regexFilter, "i");


            var builder = Builders<Users>.Filter;

            var builder2 = Builders<Users>.Filter;

            var newFunFilter2 = builder2.Regex("email", "Jack_gleeson@gameofthron.es");

            var newFunFilter = builder.Eq("email", "jack_gleeson@gameofthron.es");

            var list = collection.Find(newFunFilter2).ToList();
            var QuickResult = list.FirstOrDefault();

            Console.WriteLine("\nstart result\n");


            Console.WriteLine(QuickResult.ToBsonDocument());

            Console.WriteLine("\nend result\n");

            List<Users> results = collection.Find(filter).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No Results");
            }

            if (results.Count > 0)
            {
                Console.WriteLine("Got Results " + results.Count);
                Console.WriteLine(results[0].Email);
                foreach (var doc in results)
                {

                    Console.WriteLine(doc.ToBsonDocument());
                }
            }


            Console.WriteLine($"All Done! User count: {userCount}");

            //var coll = MongoBase.DB.GetCollection<Users>("users").AsQueryable<Users>();

            //var someBooks = coll.Where(b => b.Name == "Cersei Lannister").Skip(0).Take(10).ToArray();

            //Console.WriteLine(someBooks.ToString());

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