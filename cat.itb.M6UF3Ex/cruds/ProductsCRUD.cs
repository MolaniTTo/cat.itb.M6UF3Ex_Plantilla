using System;
using System.IO;
using System.Linq;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.M6UF3Ex.cruds
{
    public class ProductsCRUD
    {
        public void LoadProductsCollection()
        { 
            FileInfo file = new FileInfo("../../files/products.json");
            var database = MongoClusterConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            using (StreamReader sr = file.OpenText())
            {
                string productString;
                while ((productString = sr.ReadLine()) != null)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(productString);
                    collection.InsertOne(product);
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCollection products loaded");
            Console.ResetColor();
        }
        
        public void SelectChipestProduct()
        {
            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Product>("products");

            var query = booksCollection.AsQueryable<Product>(); 
        
            var minPrice =
                query
                    .Select(p => p.price)
                    .Min();
            var product =
                query
                    .Where(p => p.price == minPrice)
                    .Single();

            Console.WriteLine("El producte més barat és:{0} " + "Preu :{1} ", product.name, product.price);
        
        }

        public void SelectChipestProduct2()
        {
            var database = MongoClusterConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            var product = collection.AsQueryable()
                .OrderBy(p => p.price).First();
            Console.WriteLine("Name: " + product.name + ", Price: " + product.price);
        }

        public void  SelectTotalStock()
        {
            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Product>("products");

            var query = booksCollection.AsQueryable<Product>(); 
        
            var totalStock =
                query
                    .Select(p => p.stock)
                    .Sum();
       
            Console.WriteLine("El stock total és:{0} ", totalStock);
        
        }
        
        public void SelectTotalStock2()
        {
            var database = MongoClusterConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            var products = collection.AsQueryable().ToList();
            int totalStock = 0;
            foreach (var product in products)
                totalStock += product.stock;
            
            Console.WriteLine("Total stock: " + totalStock);
        }
    }
}