using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using static System.Net.WebRequestMethods;


namespace MongoConsoleApp.Classes
{
    public class Users
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }


        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("created")]
        public DateTime Created { get; set; }



        public Users(string name, string email, string password)
        {
            this.Name = name; this.Email = email; this.Password = password;
            // every time we insert lets datestamp it. Its easy to do.
            Created = DateTime.UtcNow.ToLocalTime();

        }


    }
}
