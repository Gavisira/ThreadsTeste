namespace ThreadsTeste.Models
{
    public class Container
    {
        public Container(Product product)
        {
            this.Product = product;
            this.Space = 1000000/product.Space;
        }
        public Product Product { get; set; }

        public int Space { get; set; }

        public bool Active { get; set; }

        public int EntryTime { get; set; }

        public int ExitTime { get; set; }
    }
}