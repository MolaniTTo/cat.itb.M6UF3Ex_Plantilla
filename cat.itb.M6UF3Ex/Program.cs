using System;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.cruds;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.M6UF3Ex
{
    internal class Program
    {
        public static void Main()
        {
            var program = new Program();
            program.Start();
        }

        public void Start()
        {
            do
            {
                PrintMenu();
            } while (!ChooseOption());
        }
        
        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Exercici1:" +
                              "\n   [1] LoadBooksCollection" +
                              "\n   [2] LoadProductsCollection" +
                              "\nExercici2:" +
                              "\n   [3] DropCollection" +
                              "\nExercici3" +
                              "\n   [4] SelectJustISBNBook" +
                              "\n   [5] SelectTitleAndCategsSortedByNumPages" +
                              "\n   [6] SelectBooksByAuthor" +
                              "\n   [7] SelectBooksByPageCountInterval" +
                              "\n   [8] SelectBooksByAuthors" +
                              "\n   [9] SelectBooksByCategNotAuthor" +
                              "\n   [10] SelectChipestProduct" +
                              "\n   [11] SelectTotalStock" +
                              "\n\n[0] Exit");
            Console.ResetColor();
        }

        public bool ChooseOption()
        {
            var booksCrud = new BooksCRUD();
            var productsCrud = new ProductsCRUD();
            bool isValidOption;
            do
            {
                isValidOption = true;
                switch (Console.ReadLine())
                {
                    case "1":
                        booksCrud.LoadBooksCollection();
                        break;
                    case "2":
                        productsCrud.LoadProductsCollection();
                        break;
                    case "3":
                        DropCollection("itb", GetStringPrintInstructions());
                        break;
                    case "4":
                        booksCrud.SelectJustISBNBook();
                        break;
                    case "5":
                        booksCrud.SelectTitleAndCategsSortedByNumPages();
                        break;
                    case "6":
                        booksCrud.SelectBooksByAuthor("Danno Ferrin");
                        break;
                    case "7":
                        booksCrud.SelectBooksByPageCountInterval(300, 350, "Java");
                        break;
                    case "8":
                        booksCrud.SelectBooksByAuthors(new[] {"Charlie Collins", "Robi Sen"});
                        break;
                    case "9":
                        booksCrud.SelectBooksByCategNotAuthor("Java","Vikram Goyal");
                        break;
                    case "10":
                        productsCrud.SelectChipestProduct();
                        break;
                    case "11":
                        productsCrud.SelectTotalStock();
                        break;
                    case "0":
                        return true;
                    default:
                        Console.WriteLine();
                        isValidOption = false;
                        break;
                }
            } while (!isValidOption);
            
            PressToMenu();
            return false;
        }
        
        public void DropCollection(string database, string collection)
        {
            var db = MongoClusterConnection.GetDatabase(database);
            Console.WriteLine("S'eliminaràn {0} documents",
                db.GetCollection<Object>(collection).CountDocuments(new BsonDocument()));
            db.DropCollection(collection);
            Console.WriteLine("Resten les següents col·leccions:");
            foreach (var collectionName in db.ListCollectionNames().ToList())
                Console.WriteLine("     " + collectionName);
        }
        
        public string GetStringPrintInstructions()
        {
            Console.WriteLine("Introdueix el nom de la col·lecció que vols esborrar:");
            return Console.ReadLine();
        }

        public void PressToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n-- Press a key to return to the menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}