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
            Germ germ1 = new Germ("A");

            world.CreateWorld("--");
            world.PlaceGerm(25, 25, germ1);

            //string[,] world = new string[50, 50];
            //Utils.PopulateArray(world,"--");
            //Utils.PlaceGerm(world,25,25 ,germ1);

            do
            {

                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1000);
                    world.PrintWorld();
                    //Utils.PrintArray(world);
                    
                    //do something
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);


 


        }
    }

}
