using System.Collections.Generic;
using ThreadsTeste.Models;
using System.Linq;
using System.Threading;

namespace ThreadsTeste.Controllers
{
    public class ContainerController
    {
        private static List<Container> Containers = new List<Container>();
        private static Mutex mutex = new Mutex();

        public List<Product> GetProductsOfActiveContainers()
        {
            return Containers.Select(c => c.Product).OrderByDescending(c=> c.Space).ToList();
        }

        public static void InitContainers(List<Container> containers)
        {
            Containers.AddRange(containers);

            Containers = Containers.Where(c=> c.ExitTime != 1).OrderBy(c=> c.Capacity).ToList();
            for (int i = 0; i < 4; i++)
            {
                Containers[i].SetActive();
            } 
        }

        public void AlterAtiveContainers(List<Order> orders){
            try
            {
                mutex.WaitOne();

                var time = Thread.CurrentThread.GetTime();
                var co = Containers.Where(
                    c=> c.Active &&  
                    !orders
                        .Where(o=> o.EntryTime <= time)
                        .Select(o=> o.ProductId)
                        .Contains(c.Product.Id)
                );


                foreach(Container c in co)
                {
                    c.SetInative(time);
                }

                SetContainerActive(co.Count(),time);
                
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            //altera o container ativo
            //adiciona time contoller o tempo para a thead atual
            //adicionar o tempo de troca de container
        }

        public void SetContainerActive(int quant, int threadTime)
        {
            Thread.CurrentThread.AddTime(30);
            Containers = Containers.Where(c=> c.ExitTime != threadTime).OrderBy(c=> c.Capacity).ToList();
            for (int i = 0; i < quant; i++)
            {
                Containers[i].SetActive();
            }   
        }

    }
}