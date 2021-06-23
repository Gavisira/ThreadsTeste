using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTeste.Controllers
{
    public class MainController
    {
        public static Thread Mat01 = new Thread(new Mat().Run);
        public static Thread Mat02 = new Thread(new Mat().Run);
        public static bool ProcessStarts = false;
        public static void StartProcess() => ProcessStarts = true;
        public static void StopProcess() => ProcessStarts = false;

        public static void RunTheads()
        {

            StartProcess();

            Mat01.Start();
            Mat02.Start();
            TimerController.ThreadTimes.Add(new ThreadTime(Mat01, 0));
            TimerController.ThreadTimes.Add(new ThreadTime(Mat02, 0));
        }

        public static void InitControllers()
        {
            DeliveryController.Orders = ReadFile.ReadOrdersList("./data/Teste1.txt");

        }
        public static List<Order> Load(int quantity)
        {
            var newOrders = new List<Order>();
            for (int i = 0; i < quantity; i++)
            {
                var line = Console.ReadLine();
                newOrders.Add(GetOrderByLine(line));
            }

            return newOrders;
        }

        public static void RestartProcess()
        {
            ProcessStarts = true;
            if (Mat01.ThreadState == ThreadState.Stopped)
            {
                Mat01 = new Thread(new Mat().Run);
                Mat01.Start();
            }
            if (Mat02.ThreadState == ThreadState.Stopped)
            {
                Mat02 = new Thread(new Mat().Run);
                Mat02.Start();
            }
        }

        public static Order GetOrderByLine(string line){
            string[] splitter = line.Split(";");

            return new Order(
                splitter[0],
                int.Parse(splitter[1]), 
                int.Parse(splitter[2]) == 0? int.MaxValue : int.Parse(splitter[2]),
                int.Parse(splitter[3]),
                int.Parse(splitter[4])
            );
        }


    }
}