using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Model
{
    public class World
    {
        Germ[,] world { get; set; }
        public World()
        {
            world = new Germ[50, 50];
        }

        public World(int y, int x)
        {
           world = new Germ[y, x];
        }

        public void CreateWorld(string value)
        {
            Germ germ = new Germ(value);
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int k = 0; k < world.GetLength(0); k++)
                {
                    world[i, k] = germ;
                }
            }
        }

        public void WorldUpdate()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int k = 0; k < world.GetLength(0); k++)
                {

                }
  
            }
        }

        public void PrintWorld()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int k = 0; k < world.GetLength(0); k++)
                {
                    Console.Write(world[i, k]);
                }
                Console.WriteLine();
            }
        }

        public void PlaceGerm( int Y, int X, Germ germ)
        {
            world[Y, X] = germ.Name + germ.Age;
        }
    }
}
