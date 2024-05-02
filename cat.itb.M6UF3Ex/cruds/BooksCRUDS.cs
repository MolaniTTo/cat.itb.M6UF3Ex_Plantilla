using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.M6UF3Ex.cruds
{
    public class BooksCRUD
    {
        public void LoadBooksCollection()
        {
            FileInfo file = new FileInfo("../../files/books.json");
            string fileString = file.OpenText().ReadToEnd();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(fileString);

            var database = MongoClusterConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            try
            {
                if (books != null)
                    collection.InsertMany(books);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCollection books loaded");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection couldn't be inserted");
            }
            Console.ResetColor();
        }
      
        
        public void  SelectJustISBNBook()
        {
            
            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Book>("books");

            var books =
                booksCollection.AsQueryable<Book>();
            
            foreach (var book in books)
            {
                Console.WriteLine(book.isbn);
            }
        }
        
        public void SelectTitleAndCategsSortedByNumPages()
        {

            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Book>("books");

            var books =
                booksCollection.AsQueryable<Book>()
                    .OrderByDescending(b => b.pageCount);
            
            foreach (var book in books)
            {
                Console.WriteLine("Titol: {0}",book.title);
        
                foreach (var categ in book.categories)
                {
                    Console.WriteLine("Categoria: {0}", categ);
                }
            }
               
        }
        
        public void SelectBooksByAuthor(String pAuthor)
        {

            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Book>("books");

            var books =
                booksCollection.AsQueryable<Book>()
                    .Where(b => b.authors.Contains(pAuthor));

            foreach (var book in books)
            {
                Console.WriteLine("Title :{0}", book.title);

                foreach (var author in book.authors)
                {
                    Console.WriteLine("Autor :{0}", author);
                }
            }
        }

        public void SelectBooksByPageCountInterval(int pMin, int pMax, String pCat)
        {
            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Book>("books");

            var query =
                booksCollection.AsQueryable<Book>()
                    .Where(b => b.pageCount >= pMin && b.pageCount <= pMax)
                    .Where(b => b.categories.Contains(pCat));
                       
            foreach (var book in query)
            {
                Console.WriteLine("Title :{0}", book.title);
                Console.WriteLine("Number of pages :{0}", book.pageCount);
                foreach (var author in book.authors)
                {
                    Console.WriteLine("Author :{0}", author);
                }
            }
        }
        
        public void SelectBooksByAuthors(String[] pAutors)
        {
            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Book>("books");

            var query =
                booksCollection.AsQueryable<Book>()
                    .Where(b => b.authors.Contains(pAutors[0]))
                    .Where(b => b.authors.Contains(pAutors[1]));

            foreach (var book in query)
            {
                Console.WriteLine("Title :{0}", book.title);
                foreach (var author in book.authors)
                {
                    Console.WriteLine("Author :{0}", author);
                }
            }
        }

        public void SelectBooksByCategNotAuthor(String pCateg, String pAutor)
        {
       
            var database = MongoClusterConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Book>("books");

            var query =
                booksCollection.AsQueryable<Book>()
                    .Where(b => b.categories.Contains(pCateg))
                    .Where(b => !b.authors.Contains(pAutor))
                    .OrderBy(b => b.title);

            foreach (var book in query)
            {
                Console.WriteLine("Title :{0}", book.title);
           
            }
        }
    }
}