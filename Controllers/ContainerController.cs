using System.Collections.Generic;
using ThreadsTeste.Models;
using System.Linq;

namespace ThreadsTeste.Controllers
{
    public class ContainerController
    {
        private List<Container> ActiveContainers = new List<Container>();

        public List<Product> GetActiveContainers()
        {
            return this.ActiveContainers.Select(c => c.Product).ToList();
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
        }

    }
}