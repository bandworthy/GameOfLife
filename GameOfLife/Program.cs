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

            //Console.BackgroundColor = ConsoleColor.Green;
            bool startlife = false;
            string line = "0";
            Menu();
            World world = AndThereBeLight();
            //Thread.Sleep(2000);
            //Console.WriteLine("Press Spacebar to begin!");
            do
            {
                 line = Console.ReadLine();
                switch (line)
                { 
                    case "1":
                        {
                            world = Secondcoming();
                            startlife = true;
                            break;
                        }
                    case "2":
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


            } while (startlife != true); //(Console.ReadKey(true).Key != ConsoleKey.Spacebar);

            //Console.BackgroundColor = ConsoleColor.Black;
            //Thread.Sleep(2000);
            //World world = new World();
            //world.CreateWorld("--");

            //test germ

           
            
            //Germ germ = new Germ("B",0,5,15,6);
            //world.PlaceGerm(42, 10, germ);

            //Germ germ2 = new Germ("C", 0, 8, 5, 1);
            //world.PlaceGerm(38, 40, germ2);

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

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("###########################################");
            Console.WriteLine("#       Welcome to A-life sim!            #");
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#  Press Key to select option             #");
            Console.WriteLine("#  1. Load Previous World                 #");
            Console.WriteLine("#  2. Start Fresh new World               #");
            Console.WriteLine("#  3. Exit                                #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#                      O                  #");
            Console.WriteLine("#                     # OX                #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
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
    }

}
