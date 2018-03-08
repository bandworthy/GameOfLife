using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife.Model;
using GameOfLife.Utilities;
namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            bool startlife = false;
            string line = "0";
            Menu();
            World world = AndThereBeLight();
            do
            {
                 line = Console.ReadLine();
                switch (line)
                { 
                    case "1":
                        {
                            world = Secondcoming();
                            startlife = true;
                            Universe(world);
                            break;
                        }
                    case "2":
                        {
                            startlife = true;
                            Universe(world);
                            break;
                        }
                    case "3":
                        {
                            startlife = true;
                            break;
                        }
                    default:
                        {
                            startlife = false;
                            break;
                        }
                }
            } while (startlife != true);


        }

        public static void Menu()
        {
            Console.SetWindowSize(100, 30);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                             ###########################################");
            Console.WriteLine("                             #       Welcome to A-life sim!            #");
            Console.WriteLine("                             ###########################################");
            Console.WriteLine("                             #                                         #");
            Console.WriteLine("                             #  Press Key to select option             #");
            Console.WriteLine("                             #  1. Load Previous World                 #");
            Console.WriteLine("                             #  2. Start Fresh new World               #");
            Console.WriteLine("                             #  3. Exit                                #");
            Console.WriteLine("                             #                                         #");
            Console.WriteLine("                             #                      O                  #");
            Console.WriteLine("                             #                     # OX                #");
            Console.WriteLine("                             #                                         #");
            Console.WriteLine("                             #                                         #");
            Console.WriteLine("                             ###########################################");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static World AndThereBeLight()
        {
            World world = new World();
            world.CreateWorld("--");
            world.PlaceGerm(25, 25, "A");
            return world;
        }
        public static World Secondcoming()
        {
            World world = new World();
            world.GetWorld();
            return world;
        }

        private static void Universe(World world)
        {
            do
            {

                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1000);
                    world.PrintWorld();
                    world.WorldUpdate();
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            world.SaveWorld();
        }
    }

}
