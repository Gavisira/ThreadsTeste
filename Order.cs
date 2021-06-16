using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadsTeste
{
    public class Order
    {

        public Order(string clientName, int productQuantity, int deadline)
        {
            this.ClientName = clientName;
            this.ProductQuantity = productQuantity;
            this.Deadline = deadline;

        }
        public string ClientName { get; set; }-        public int ProductQuantity { get; set; }
        public int Deadline { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();

        public void Execute(ref int time)
        {
            //pede o produto para a controller de distribuição
            var product = new Product(1, 100);
            var packagesQuantity = Package.GetPackagesQuantity(this.ProductQuantity); //4
            for (int i = 0; i < packagesQuantity; i++)
            {
                var products = new List<Product>();
                

                var package = new Package(
                    products;
                );
                this.Packages.Add(package);
                this.ProductQuantity -= package.ProductsQuantity;
            }
        }

        private void Pack(int productQuantity, )
        {
            
                var maxProducts = Package.GetMaxProducts(product.Space);

                var quantityProducts =productQuantity > maxProducts? maxProducts: productQuantity;
                for (int j = 0; j < quantityProducts; j++)
                {
                    products.Add(product);
                }
        }

        public static List<Order> OrderByDeadlineAndQuantity(List<Order> orders){
            return orders.OrderBy(x => x.Deadline).ThenBy(x => x.ProductQuantity).ToList();
        }

        
    }
}