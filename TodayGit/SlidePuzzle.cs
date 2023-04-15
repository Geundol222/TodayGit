using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayGit
{
    

    public class SlidePuzzle
    {
        public enum Direction { Up, Down, Left, Right, None}

        public void GameStart()
        {
            Console.CursorVisible = true;

            Console.Clear();

            int[,] map = RandomNumber();

            RenderMap(map);

            while (true)
            {
                Direction dir = GameInput();

                map = GameUpdate(dir, map);

                RenderMap(map);
            }
        }

        public Direction GameInput()
        {
            Direction dir;

            ConsoleKeyInfo info = Console.ReadKey();

            switch(info.Key)
            {
                case ConsoleKey.UpArrow:
                    dir = Direction.Up; 
                    break;
                case ConsoleKey.DownArrow:
                    dir = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    dir = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    dir = Direction.Right;
                    break;
                default:
                    dir = Direction.None;
                    break;
            }
            return dir;
        }

        public int[,] GameUpdate(Direction input, int[,] map)
        {
            switch (input)
            {
                case Direction.Up:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            if (map[j, i] == 0)
                            {
                                if (i - 1 >= 0)
                                {
                                    int temp = map[j, i];
                                    map[j, i] = map[j, i - 1];
                                    map[j, i - 1] = temp;
                                    break;
                                }
                                else
                                    break;
                            }
                        }
                    }
                    break;
                case Direction.Down:
                    for (int i = map.GetLength(0) - 1; i >= 0; i--)
                    {
                        for (int j = map.GetLength(1) - 1; j >= 0; j--)
                        {
                            if (map[j, i] == 0)
                            {
                                if (i + 1 < 5)
                                {
                                    int temp = map[j, i];
                                    map[j, i] = map[j, i + 1];
                                    map[j, i + 1] = temp;
                                    break;
                                }
                                else
                                    break;
                            }
                        }
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            if (map[j, i] == 0)
                            {
                                if (j - 1 >= 0)
                                {
                                    int temp = map[j, i];
                                    map[j, i] = map[j - 1, i];
                                    map[j - 1, i] = temp;
                                    break;
                                }
                                else
                                    break;
                            }
                        }
                    }
                    break;
                case Direction.Right:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            if (map[j, i] == 0)
                            {
                                if (j + 1 < 5)
                                {
                                    int temp = map[j, i];
                                    map[j, i] = map[j + 1, i];
                                    map[j + 1, i] = temp;
                                    break;
                                }
                                else
                                    break;
                            }
                        }
                    }
                    break;               
            }
            return map;
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

        public void RenderMap(int[,] map)
        {
            Console.Clear();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write($" {map[j, i]}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("← 왼쪽, ↑ 위쪽, ↓ 아래쪽, → 오른쪽");
        }
    }
}
