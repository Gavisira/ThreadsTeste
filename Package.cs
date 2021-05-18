using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTeste
{
    public class Package
    {
        public Package(int productsQuantity, ref int time)
        {
            this.ProductsQuantity = productsQuantity;
            for (int i = 0; i < this.ProductsQuantity; i++)
            {
                this.Products.Add(new Product());
            }

            time +=Time;
        }
        public static int Limit { get; } = 5000;
        public static int Time { get; } = 5;
        public List<Product> Products { get; set; } = new List<Product>();
        public int ProductsQuantity { get; set; }

        public static int GetMaxProducts() =>Limit / Product.Space;

        public static int GetPackagesQuantity(int productQuantity)
        {
            var quantity = productQuantity / GetMaxProducts();

            return productQuantity % GetMaxProducts() == 0 ? quantity : (quantity+1);
        }

    }
}