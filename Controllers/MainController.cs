using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsTeste.Controllers
{
    public class MainController
    {
        public static Thread Mat01 = new Thread(new MatController().RunMat);
        public static Thread Mat02 = new Thread(new MatController().RunMat);
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
            DeliveryController.Orders = ReadFile.ReadOrdersList(@"C:\Users\gabri\Documents\GitHub\ThreadsTeste\Data\Empacotadeira.txt");
            ContainerController.InitContainers(ReadFile.ReadContainerList(@"C:\Users\gabri\Documents\GitHub\ThreadsTeste\Data\Teste1.txt"));

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