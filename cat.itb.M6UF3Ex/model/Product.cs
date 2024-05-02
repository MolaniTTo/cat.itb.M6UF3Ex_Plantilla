using System.Collections.Generic;

namespace cat.itb.M6UF3Ex.model
{
    public class Product
    {
        public int _id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public string picture { get; set; }
        public List<string> categories { get; set; }
    }
}