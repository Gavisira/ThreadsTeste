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
        public string ClientName { get; set; }
        public int ProductQuantity { get; set; }
        public int Deadline { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();

        public void Execute(ref int time)
        {
            var packagesQuantity = Package.GetPackagesQuantity(this.ProductQuantity); //4
            for (int i = 0; i < packagesQuantity; i++)
            {

                var package = new Package(
                    this.ProductQuantity > Package.GetMaxProducts()? Package.GetMaxProducts(): this.ProductQuantity,
                    ref time
                );
                this.Packages.Add(package);
                this.ProductQuantity -= package.ProductsQuantity;
            }
        }

        public static List<Order> OrderByDeadlineAndQuantity(List<Order> orders){
            return orders.OrderBy(x => x.Deadline).ThenBy(x => x.ProductQuantity).ToList();
        }

        
    }
}