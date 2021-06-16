using System;
using System.Collections.Generic;

namespace ThreadsTeste.controllers
{
    public class DeliveryController
    {
        public static List<Order> Orders;
        public static List<Product> Products;

        public (Order, Product) GetNextOrder() 
        {
            //trava o mutex
            //busca na container controller os produtos disponiveis, se não tiver produtos pede a toca dos containers
            //verifica para a thread atual qual o tempo de execução
            //pega o pedido para o produto retornado pelo container controller
            //destrava o mutex
            //retorna o pedido e o produto assim => (order, product)
            throw new NotImplementedException();

        }
        
    }
}