using System;
using System.Collections.Generic;
using System.IO;
using ThreadsTeste.Controllers;

namespace ThreadsTeste
{
    public class ReadFile
    {
        public static List<Order> ReadOrdersList(string path)
        {
            var list = new List<Order>();

            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        Console.WriteLine(path);

                        String line = sr.ReadLine();
                        Console.WriteLine(line);

                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);

                            list.Add(MainController.GetOrderByLine(line));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return list;
        }
    }
}