using System.Collections.Generic;
using ThreadsTeste.Models;
using System.Linq;

namespace ThreadsTeste.Controllers
{
    public class ContainerController
    {
        private static List<Container> Containers = new List<Container>();

        public List<Product> GetProductsOfActiveContainers()
        {
            return Containers.Where(c=> c.Active).Select(c => c.Product).OrderByDescending(c=> c.Space).ToList();
        }

        public void InitContainers()
        {
            //inicia o container com o produto informado na lista 
            //adiciona ele na lista de containers
            //ativa os primeiros containes
        }

        public void AlterAtiveContainers(){
            //altera o container ativo
            //adiciona time contoller o tempo para a thead atual
            //adicionar o tempo de troca de container
        }

    }
}