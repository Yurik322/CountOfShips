//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="My Company">
//    Created by yurik_322 on 20/03/10.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace CountOfShips
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.SumOfShips();

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }
    }
}
