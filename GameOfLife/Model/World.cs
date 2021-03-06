﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
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
            NoGerm EmptyGround = new NoGerm();
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int k = 0; k < world.GetLength(0); k++)
                {
                    world[i, k] = EmptyGround;
                }
            }
        }

        public void WorldUpdate()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int k = 0; k < world.GetLength(0); k++)
                {
                    if (world[i,k].GetType().IsAssignableFrom(typeof(Germ)) && world[i,k].Age >= world[i,k].MaxAge)
                    {
                        DeadGerm dead = new DeadGerm(world[i, k].CorpseLast);
                        world[i,k] = dead;
                        continue;
                    }
                    if (world[i,k] is DeadGerm && world[i,k].Age < 1)
                    {
                        NoGerm gone = new NoGerm();
                        world[i, k] = gone;
                        continue;
                    }



                    if(world[i,k].GetType().IsAssignableFrom(typeof(Germ)) && world[i,k].Age < world[i,k].MaxAge)
                    {
                            GermDivide(i, k, world[i, k]);
                            
                    }
                    world[i, k].GermAge();

                }
            }
        }

        public void PrintWorld()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int k = 0; k < world.GetLength(0); k++)
                {
                    world[i, k].PrintStats();
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hit ESC key to exit Program");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SaveWorld()
        {
           var filePath = @"C:\Shane\world.json";

            var output = JsonConvert.SerializeObject(world,Formatting.Indented);
            System.IO.File.WriteAllText(filePath, output);

        }

        public void GetWorld()
        {
            
            var filePath = @"C:\Shane\world.json";
            var input = System.IO.File.ReadAllText(filePath);

            // List<Germ> iworld = JsonConvert.DeserializeObject<List<Germ>>(input);
            Germ[,] iworld = JsonConvert.DeserializeObject<Germ[,]>(input);
            //using (StreamReader file = File.OpenText(@"C:\Shane\world.json"))
            //{
            //    string json = file.ReadToEnd();
            //    JsonSerializer serializer = new JsonSerializer();

            //}
            //World world2 = JsonConvert.DeserializeObject<World>(input);
            for (int i = 0; i < iworld.GetLength(0); i++)
            {
                for (int k = 0; k < iworld.GetLength(0); k++)
                {
                    this.world[i,k] = iworld[i,k];
                }
                //Console.WriteLine();
            }

        }

        public void PlaceGerm( int Y, int X, string name)
        {
            Germ germ = new Germ(name);
            world[Y, X] = germ;
        }

        public void PlaceGerm(int Y, int X, Germ germ)
        {
            world[Y, X] = germ;
        }

        private void GermDivide(int Y, int X, Germ germ)
        {

            // if it has no room it dies.
            bool growth = false;
            //Binaryfission
            Random rnd = new Random();
            int DivideNumber = rnd.Next(germ.Binaryfission);
            
            if (DivideNumber % 2 == 0)
            {
 
                if (X != 0 && X != world.GetLength(0) - 1)
                {
                    //Left 4
                    if (world[Y, X - 1] is NoGerm && world[Y, X].Age > 1)
                    {
                        Germ gerrmy = new Germ(germ.Name);
                        world[Y, X - 1] = gerrmy;
                        growth = true;
                    }
                    //Right 6
                    if (world[Y, X + 1] is NoGerm && world[Y, X].Age > 1)
                    {
                        Germ gerrmy = new Germ(germ.Name);
                        world[Y, X + 1] = gerrmy;
                        growth = true;
                    }
                    if(world[Y,X].EatsDeadBacteria == true)
                    {
                        // left 4 Eat
                        if (world[Y, X - 1] is DeadGerm && world[Y, X].Age > world[Y, X].Age / 2)
                        {
                            if (world[Y, X].Age >= 1)
                            {
                                world[Y, X].Age--;
                            }
                            NoGerm gerrmy = new NoGerm("--");
                            world[Y, X - 1] = gerrmy;
                            growth = true;
                        }
                        // right 6 Eat
                        if (world[Y, X + 1] is DeadGerm && world[Y, X].Age > world[Y, X].Age / 2)
                        {
                            if (world[Y, X].Age >= 1)
                            {
                                world[Y, X].Age--;
                            }
                            NoGerm gerrmy = new NoGerm("--");
                            world[Y, X + 1] = gerrmy;
                            growth = true;
                        }
                    }

                }
            }
            else
            {
                if (Y != 0 && Y != world.GetLength(0) - 1)
                {
                    // Up 8 
                    if (world[Y - 1, X] is NoGerm && world[Y, X].Age > 1)
                    {
                        Germ gerrmy = new Germ(germ.Name);
                        world[Y - 1, X] = gerrmy;
                        growth = true;
                    }
                    // Down 2
                    if (world[Y + 1, X] is NoGerm && world[Y, X].Age > 1)
                    {
                        Germ gerrmy = new Germ(germ.Name);
                        world[Y + 1, X] = gerrmy;
                        growth = true;
                    }
                    if (world[Y, X].EatsDeadBacteria == true)
                    {
                        // Up 8 eat
                        if (world[Y - 1, X] is DeadGerm && world[Y, X].Age > world[Y, X].Age / 2)
                        {
                            if (world[Y, X].Age >= 1)
                            {
                                world[Y, X].Age--;
                            }
                            NoGerm gerrmy = new NoGerm("--");
                            world[Y - 1, X] = gerrmy;
                            growth = true;
                        }
                        // Down 2 eat
                        if (world[Y + 1, X] is DeadGerm && world[Y, X].Age > world[Y, X].Age / 2)
                        {
                            if (world[Y, X].Age >= 1)
                            {
                                world[Y, X].Age--;
                            }
                            NoGerm gerrmy = new NoGerm("--");
                            world[Y + 1, X] = gerrmy;
                            growth = true;
                        }
                    }
                }
            }

            if (growth == false && germ.Age > 1)
            {
                germ.Age = germ.MaxAge;
            }


        }
    }
}
