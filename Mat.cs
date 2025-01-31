using System;
using System.Collections.Generic;
using System.Threading;
using ThreadsTeste.Controllers;

namespace ThreadsTeste
{
    public class Mat
    {
        public static Queue<Order> OrdersQueue = new Queue<Order>();
        public static bool Mutex = false;
        private static void StartMutex() => Mutex = true;
        private static void StopMutex() => Mutex = false;


/*
        public void Run()
        {
            var time = 0;
            while (MainController.ProcessStarts)
            {
                if (QueueIsEmpty()) return;
                var order = Dequeue(); //1 3
                Console.WriteLine("Thread {0} Trabalhando com o Pedido {1}", Thread.CurrentThread.ManagedThreadId, order.ClientName);
                order.Execute(ref time);

                Console.WriteLine("Thread {0} tempo da thread {1}", Thread.CurrentThread.ManagedThreadId, time);
            }
        }*/



        public static Order Dequeue()
        {
            //receber o tempo
            //localizar o proximo pedido procurando pelo menor prioridade e menor quantidade de produtos 
            //
            while (Mutex) { /*Console.WriteLine("Aguardando mutex");*/ }

            StartMutex();

            var order = OrdersQueue.Dequeue();

            StopMutex();

            return order;
        }

        public static void Enqueue(List<Order> orders, bool clear = false)
        {
            while (Mutex) { /*Console.WriteLine("Aguardando mutex");*/ }

            StartMutex();

            if(clear){

                foreach (Order item in OrdersQueue)
                {
                    orders.Add(item);
                }

                OrdersQueue.Clear();

                orders = Order.OrderByDeadlineAndQuantity(orders);
            }

            foreach (Order item in orders)
            {
                OrdersQueue.Enqueue(item);
            }

            StopMutex();
        }

        public static bool QueueIsEmpty()
        {
            bool empty;
            while (Mutex) { /*Console.WriteLine("Aguardando mutex");*/ }

            StartMutex();

            empty = OrdersQueue.Count == 0;

            StopMutex();

            return empty;
        }
        
    }
}