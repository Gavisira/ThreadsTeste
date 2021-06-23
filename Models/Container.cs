using System.Threading;
using ThreadsTeste.Controllers;
namespace ThreadsTeste.Models
{
    public class Container
    {
        public Container(Product product)
        {
            this.Product = product;
            this.Capacity = 1000000/product.Space;
        }
        public Product Product { get; set; }

        public int Capacity { get; set; }

        public bool Active { get; private set; } = false;

        public bool Consumed { get; private set; } = false;

        public int ExitTime { get; private set; }

        public void SetActive()
        {
            this.Active = true;
            this.Consumed = true;
        }

        public void SetInative(int threadTime)
        {
            this.Active = false;
            this.ExitTime = threadTime;
        }

    }
}