namespace ProductsApiTask.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Emri { get; set; }
        public decimal Cmimi { get; set; }
        public int Sasia { get; set; }

     
        public int CategoryID { get; set; }   // Celesi i jashtem


        public Category Category { get; set; }
    }
}