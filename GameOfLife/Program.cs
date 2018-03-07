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


            Console.WriteLine("Welcome to the game of life");
            //Thread.Sleep(3000);
            Console.WriteLine("Hit ESC key to exit Program");
            //Thread.Sleep(2000);
            World world = new World();
            world.CreateWorld("--");

            //test germ
            world.PlaceGerm(25, 25, "A");

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
