namespace ThreadsTeste.Models
{
    public class Container
    {
        public Container(Product product, int space)
        {
            this.Product = product;
            this.Space = space;
        }
        public Product Product { get; set; }

        public int Space { get; set; }

        public bool Active { get; set; }

        public int EntryTime { get; set; }

        public int ExitTime { get; set; }
    }
}