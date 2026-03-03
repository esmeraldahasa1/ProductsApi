namespace ProductsApiTask.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Emri { get; set; }
        public decimal Cmimi { get; set; }
        public int Sasia { get; set; }

        // Foreign Key
        public int CategoryID { get; set; }

        // Navigation Property
        public Category Category { get; set; }
    }
}