using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTeste
{
    public class Controller
    {
        public static Thread Mat01 = new Thread(new Mat().Run);
        public static Thread Mat02 = new Thread(new Mat().Run);
        public static Thread Main = new Thread(Run);
        public static bool ProcessStarts = false;
        public static void StartProcess() => ProcessStarts = true;
        public static void StopProcess() => ProcessStarts = false;

        public static void Run()
        {
            while (ProcessStarts)
            {
                var input = Console.ReadLine();
                if (input == "0") StopProcess();
                if (input == "2")
                {
                    StopProcess();
                    var quant = Console.ReadLine();
                    var orders  = Load(int.Parse(quant));
                    Mat.Enqueue(orders, true);
                    Program.PrintValues(Mat.OrdersQueue);
                    StartProcess();
                }
            }
        }

        public static void RunTheads()
        {
            StartProcess();

            Mat01.Start();
            Mat02.Start();
            Main.Start();
        }

        public static void InitQueue()
        {
            var orders = new List<Order>() { new Order("Lucas 0", 43, 1), new Order("Lucas 1", 83, 1), new Order("Lucas 2", 40, 1) };
            //Bucar o txt com os dados dos pedidos com tempo 0
            //carregar eles em uma lista de pedidos => var orders = new List<Order>()
            Mat.Enqueue(Order.OrderByDeadlineAndQuantity(orders));

        }

        //todo Adicionar novos pedidos ao longo da execução
        public static List<Order> Load(int quantity)
        {
            return new List<Order>();
        }

        public static void RestartProcess()
        {
            ProcessStarts = true;
            if (Mat01.ThreadState == ThreadState.Stopped)
            {
                Mat01 = new Thread(Run);
                Mat01.Start();
            }
            if (Mat02.ThreadState == ThreadState.Stopped)
            {
                Mat02 = new Thread(Run);
                Mat02.Start();
            }
        }


    }
}