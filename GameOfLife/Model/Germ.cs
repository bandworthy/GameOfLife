using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Model
{
    public class Germ
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Binaryfission { get; set; }
        public int MaxAge { get; set; }
        public int CorpseLast {get; set;}

        protected Germ() { }

        public Germ(string name)
        {
            this.Name = name;
            this.Age = 0;
            this.Binaryfission = 2;
            this.MaxAge = 9;
            this.CorpseLast = 3;
            
        }

        public Germ(string name,int age)
        {
            this.Name = name;
            this.Age = age;
            this.Binaryfission = 2;
            this.MaxAge = 9;
            this.CorpseLast = 3;
        }

        public Germ(string name, int age, int bFiss, int mAge, int corpse)
        {
            this.Name = name;
            this.Age = age;
            this.Binaryfission = bFiss;
            this.MaxAge = mAge;
            this.CorpseLast = corpse;
        }

        public virtual void GermAge()
        {
            this.Age++;
        }

        public virtual void PrintStats()
        {
            if (this.Age < (this.MaxAge / 2))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(this.Name + this.Age.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(this.Name + this.Age.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public class DeadGerm : Germ
    {
        public DeadGerm()
        {
            this.Name = "X";
            this.Age = 3;
        }

        public DeadGerm(int CorpseRot)
        {
            this.Name = "X";
            this.Age = CorpseRot;
        }

        public override void GermAge()
        {       
            this.Age--;
        }

        public override void PrintStats()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.Name + "X");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class NoGerm : Germ
    {
        public NoGerm()
        {
            this.Name = " ";
        }

        public override void GermAge()
        {
            this.Age = 0;
        }

        public override void PrintStats()
        {
            Console.Write(this.Name + " ");
        }


    }
}
