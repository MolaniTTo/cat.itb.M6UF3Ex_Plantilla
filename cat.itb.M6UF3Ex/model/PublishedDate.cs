namespace cat.itb.M6UF3Ex.model
{
    public class PublishedDate
    {
        public string date { get; set; }
    
        public override string ToString()
        {
            return 
                "PublishedDate{" + 
                "date = '" + date + '\'' + 
                "}";
        }
    }
}