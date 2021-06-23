using System.Collections.Generic;
using ThreadsTeste.Models;
using System.Linq;
using System.Threading;

namespace ThreadsTeste.Controllers
{
    public class ContainerController
    {
        private static List<Container> Containers = new List<Container>();

        public List<Product> GetProductsOfActiveContainers()
        {
            return Containers.Where(c=> c.Active).Select(c => c.Product).OrderByDescending(c=> c.Space).ToList();
        }

        public static void InitContainers(List<Container> containers)
        {
            Containers.AddRange(containers);
            //adiciona ele na lista de containers
            //ativa os primeiros containes
        }

        public void AlterAtiveContainers(){
            //altera o container ativo
            //adiciona time contoller o tempo para a thead atual
            //adicionar o tempo de troca de container
        }

        public void SetContainerActive(int quant)
        {

            Containers = Containers.Where(c=> !c.Consumed).OrderBy(c=> c.Capacity).ToList();
            for (int i = 0; i < quant; i++)
            {
                Containers[i].SetActive();
            }   
        }

        public void SetContainerInactive(int quant)
        {

            Containers = Containers.Where(c=> !c.Consumed).OrderBy(c=> c.Capacity).ToList();
            for (int i = 0; i < quant; i++)
            {
                Containers[i].SetInactive();
            }   
        }

        

    }
}