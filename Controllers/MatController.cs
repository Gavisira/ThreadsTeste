using System;
using System.Threading;

namespace ThreadsTeste.Controllers
{
    public class MatController
    {
        public void RunMat()
        {
            while (MainController.ProcessStarts)
            {
                var (order, product) = DeliveryController.GetNextOrder();

                Console.WriteLine("Thread {0} Trabalhando com o Pedido {1}", Thread.CurrentThread.ManagedThreadId, order.ClientName);
                
                order.Execute(product);

                Console.WriteLine("Thread {0} tempo da thread {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetTime());
            }

        }
    }
}