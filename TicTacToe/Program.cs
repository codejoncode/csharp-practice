using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int n = 3;
            int k = 1;
            var newList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                newList.Add(i);
            }
            newList.ToArray();
        }
    }
}
