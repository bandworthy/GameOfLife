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

        protected Germ() { }

        public Germ(string name)
        {
            this.Name = name;
            this.Age = 0;
            this.Binaryfission = 2;
        }

        public Germ(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual void GermAge()
        {
            this.Age++;
        }

        public virtual string PrintStats()
        {
            return this.Name + this.Age.ToString();
        }
    }

    public class DeadGerm : Germ
    {
        public DeadGerm()
        {
            this.Name = "X";
            this.Age = 3;
        }

        public override void GermAge()
        {
            this.Age--;
        }

        public override string PrintStats()
        {
            return this.Name + "X";
        }
    }

    public class NoGerm : Germ
    {
        public NoGerm()
        {
            this.Name = "-";
        }

        public override void GermAge()
        {
            this.Age = 0;
        }

        public override string PrintStats()
        {
            return this.Name + "-";
        }


    }
}
