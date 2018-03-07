using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Model;

namespace GameOfLife.Utilities
{
    public static class Utils
    {
        public static void PopulateArray(this string[,] arr, string value)
        {
            for ( int i = 0; i < arr.GetLength(0); i ++)
            {
                for (int k = 0; k < arr.GetLength(0); k++)
                {
                    arr[i, k] = value;
                }
            }
        }

        public static void PrintArray(this string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(0); k++)
                {
                    Console.Write(arr[i, k]);
                }
                Console.WriteLine();
            }
        }

        public static void PlaceGerm(this string[,] arr, int Y, int X, Germ germ)
        {
            arr[Y, X] = germ.Name+germ.Age;
        }

        public static void CheckSides()
        {

        }

        public static bool CheckLeft(this string[,] arr,int y, int x)
        {

            return false;
        }
    }
}
