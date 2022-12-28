using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WPFAuthorizationWithMongo
{
    public class DataBase
    {
        public static User? CurrentUser { get; set; }
        //Add
        public static void AddUserToDataBase(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("AuthoDataBase");
            var collection = database.GetCollection<User>("UserList");
            collection.InsertOne(user);
        }
        //Find
        public static User FindByUserLogin(string login)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("AuthoDataBase");
            var collection = database.GetCollection<User>("UserList");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();

            return user;
        }
    }
}
