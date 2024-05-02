using System;
using MongoDB.Driver;

namespace cat.itb.M6UF3Ex.connections
{
    public class MongoClusterConnection
    {
        private static string URL = "mongodb+srv://LaTevaConnexióAtlasMongoDB"; 
       
        public static IMongoDatabase GetDatabase(String database)
        {
            MongoClient dbClient = new MongoClient(URL);
            return dbClient.GetDatabase(database);
        }
    
        public static MongoClient GetMongoClient()
        {
            return new MongoClient(URL);
        }
    }
}