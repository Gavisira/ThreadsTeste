using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTeste
{
    public class Package
    {
        public Package(List<Product> products )
        {
            Products = products;
        }
        public static int Limit { get; } = 5000;
        public static int Time { get; } = 5;
        public List<Product> Products { get; set; } = new List<Product>();
        public int ProductsQuantity { get; set; }

        public static int GetMaxProducts(int productSpace) =>Limit / productSpace;

        public static int GetPackagesQuantity(int productQuantity, int productSpace)
        {
            var quantity = productQuantity / GetMaxProducts(productSpace);

            return productQuantity % GetMaxProducts(productSpace) == 0 ? quantity : (quantity+1);
        }

    }
}