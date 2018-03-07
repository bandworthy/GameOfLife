using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Model
{
    public class Terrain
    {
        //  --  =  empty
        string type { get; set; }
        public Terrain()
        {
            type = "--";
        }

    }
}
