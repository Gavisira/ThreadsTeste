using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ThreadsTeste.Controllers;

namespace ThreadsTeste
{
    public class Order
    {

        public Order(string clientName, int productQuantity, int deadline, int entryTime, int productId)
        {
            this.ClientName = clientName;
            this.ProductQuantity = productQuantity;
            this.Deadline = deadline;
            this.ProductId = productId;
            this.EntryTime = entryTime;

        }
        public string ClientName { get; set; }       
        public int ProductQuantity { get; set; }
        public int Deadline { get; set; }
        public int ProductId {get; set;}
        public bool Executed {get;set;}
        public int EntryTime { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();

        public void Execute(Product product)
        {
            var packTime = 0;
            var packagesQuantity = Package.GetPackagesQuantity(this.ProductQuantity, product.Space);
            for (int i = 0; i < packagesQuantity; i++)
            {
                var package = Pack(this.ProductQuantity, product);
                this.Packages.Add(package);
                this.ProductQuantity -= package.ProductsQuantity;
                packTime += Package.Time;
            }

            Thread.CurrentThread.AddTime(packTime);
        }

        private Package Pack(int productQuantity, Product product)
        {
                var products = new List<Product>();
                var maxProducts = Package.GetMaxProducts(product.Space);

                var quantityProducts =productQuantity > maxProducts? maxProducts: productQuantity;
                for (int j = 0; j < quantityProducts; j++)
                {
                    products.Add(product);
                }

                return new Package(
                    products
                );
        }

        public static List<Order> OrderByDeadlineAndQuantity(List<Order> orders){
            return orders
                .Where(c=> c.EntryTime <= Thread.CurrentThread.GetTime())
                .OrderBy(x => x.Deadline)
                .ThenBy(x => x.ProductQuantity)
                .ToList();
        }

        
    }
}