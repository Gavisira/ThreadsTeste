using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ThreadsTeste.Controllers
{
    public class DeliveryController
    {
        private static Mutex mutex = new Mutex();

        public static List<Order> Orders = new List<Order>();
        public static List<Product> Products;

        public static (Order, Product) GetNextOrder() 
        {
            mutex.WaitOne();

            var containerCtrl = new ContainerController();

            var threadTime = Thread.CurrentThread.GetTime();

            while(Orders.Any(c=> !c.Executed))
            {
                var products = containerCtrl.GetProductsOfActiveContainers();
                try
                {
                    return FindOrder(products);
                    
                }
                catch (Exception)
                {
                    containerCtrl.AlterAtiveContainers();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }

                throw new Exception();
            
            


            //trava o mutex
            //busca na container controller os produtos disponiveis, se não tiver produtos pede a toca dos containers
            //verifica para a thread atual qual o tempo de execução
            //pega o pedido para o produto retornado pelo container controller
            //destrava o mutex
            //retorna o pedido e o produto assim => (order, product)
            //throw new NotImplementedException();

        }

        private static (Order, Product) FindOrder(List<Product> products)
        {
            foreach (Product item in products)
            {
                var ordersToProduct = Orders.Where(c=> c.ProductId == item.Id && !c.Executed).ToList();
                if (ordersToProduct.Any())
                {
                    var order = Order.OrderByDeadlineAndQuantity(ordersToProduct).First();
                    return(order, item);
                }
            }

            throw new Exception();
        }
        
    }
}