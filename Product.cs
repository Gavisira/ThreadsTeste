namespace ThreadsTeste
{
    public class Product
    {
        public int Id { get; set; }
        public int Space { get; set; } = 250;

        public Product(int id, int space)
        {
            Id = id;
            Space = space;
        }
    }
}
