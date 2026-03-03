namespace ProductsApiTask.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Emri { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}