using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayGit
{
    internal class SlidePuzzle
    {
        enum Direction { Up, Down, Left, Right, None}

        struct Player
        {
            public int x;
            public int y;
        }

        public int[,] RandomNumber()
        {
            Random rand = new Random();
            int[] num = new int[25];
            int[,] number = new int[5, 5];
            int index = 0;

            for (int i = 0; i < num.Length; i++)
            {
                num[i] = rand.Next(0, 25);
                for (int j = 0; j < i; j++)
                {
                    if (num[i] == num[j])
                    {
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    number[i, j] = num[index++];
                }
            }
            return number;
        }

        public void RenderMap(int[,] number)
        {
            for (int i = 0; i < number.GetLength(0); i++)
            {
                for (int j = 0; j < number.GetLength(1); j++)
                {
                    Console.Write($" {number[i, j]}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
