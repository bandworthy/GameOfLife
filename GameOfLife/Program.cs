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
            Console.WriteLine("Welcome to the game of life");
            Thread.Sleep(3000);
            Console.WriteLine("Press Spacebar to begin!");
            do
            {

            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);

            //Console.BackgroundColor = ConsoleColor.Black;

            //Thread.Sleep(2000);
            World world = new World();
            world.CreateWorld("--");

            //test germ

            world.PlaceGerm(25, 25, "A");
            
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


 


        }
    }

}
