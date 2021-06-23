using System;
using System.Collections.Generic;
using System.IO;
using ThreadsTeste.Controllers;
using System.Linq.Expressions;
using ThreadsTeste.Models;

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

        public static List<Container> ReadContainerList(string path)
        {
            var list = new List<Container>();

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
                            string[] data = line.Split(";");
                            list.Add(new Container(new Product(int.Parse(data[0]), int.Parse(data[1]))));
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