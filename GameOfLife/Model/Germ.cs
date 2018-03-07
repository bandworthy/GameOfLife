﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Model
{
    public class Germ
    {
        public string Name { get; set; }
        public int Age { get; set; }


        protected Germ() { }

        public Germ(string name)
        {
            this.Name = name;
            this.Age = 0;
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
            this.Age = 9;
        }

        public override void GermAge()
        {
            this.Age--;
        }
    }

    public class NoGerm : Germ
    {
        public NoGerm()
        {
            this.Name = "-";
        }

        public override string PrintStats()
        {
            return this.Name + "-";
        }


    }
}
