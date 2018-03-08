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
        public string Eats { get; set; }
        private int DefaultM_Age = 3;
        protected Germ() { }
        public bool EatsDeadBacteria { get; set; }

        public Germ(string name)
        {
            this.Name = name;
            this.Age = 0;
            this.Binaryfission = 2;
            this.MaxAge = DefaultM_Age;
            this.CorpseLast = 3;
            this.EatsDeadBacteria = false;
            
        }

        public Germ(string name,int age)
        {
            this.Name = name;
            this.Age = age;
            this.Binaryfission = 2;
            this.MaxAge = DefaultM_Age;
            this.CorpseLast = 3;
            this.EatsDeadBacteria = false;
        }

        public Germ(string name, int age, int bFiss, int mAge, int corpse)
        {
            this.Name = name;
            this.Age = age;
            this.Binaryfission = bFiss;
            this.MaxAge = mAge;
            this.CorpseLast = corpse;
            this.EatsDeadBacteria = false;
        }

        public Germ(string name, int age, int bFiss, int mAge, int corpse,bool eatsdeadBac)
        {
            this.Name = name;
            this.Age = age;
            this.Binaryfission = bFiss;
            this.MaxAge = mAge;
            this.CorpseLast = corpse;
            this.EatsDeadBacteria = eatsdeadBac;
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
                Console.Write(this.Name + this.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(this.Name + this.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool EatsOther(Germ germ)
        {
            if (this.Eats == germ.Name)
            { 
                if (this.Age > 0)
                {
                    --this.Age;
                }
                return true;
            }


            return false;
        }
    }

    public class DeadGerm : Germ
    {
        public DeadGerm()
        {
            this.Name = "X";
            this.Age = 1;
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

        public NoGerm(string name)
        {
            this.Name = "-";
        }

        public override void GermAge()
        {
            this.Age = 0;
        }

        public override void PrintStats()
        {
            Console.Write(this.Name + this.Name);
        }


    }
}
