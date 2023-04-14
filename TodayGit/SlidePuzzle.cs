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

        public struct Player
        {
            public int x;
            public int y;
        }

        public void GameStart()
        {
            Console.CursorVisible = false;

            Console.Clear();

            int?[,] map = RandomNumber();
            Player player = new Player();

            RenderMap(map, player);

            while (true)
            {
                Direction dir = GameInput(player);

                player = GameUpdate(dir, map, player);

                RenderMap(map, player);
            }
        }

        public Direction GameInput(Player player)
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

        public Player GameUpdate(Direction input, int?[,] map, Player player)
        {
            Player prevPlayer = player;

            switch (input)
            {
                case Direction.Up:
                    player.y--;
                    break;
                case Direction.Down:
                    player.y++;
                    break;
                case Direction.Left:
                    player.x--;
                    break;
                case Direction.Right:
                    player.x++;
                    break;               
            }

            if (map[player.y, player.x] == null)
                player = prevPlayer;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == map[player.y, player.x])
                    {
                        i = prevPlayer.y;
                        j = prevPlayer.x;
                    }                    
                }                
            }

            return player;
        }

        public int?[,] RandomNumber()
        {
            Random rand = new Random();
            int[] num = new int[25];
            int?[,] number = new int?[5, 5];
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

        public void RenderMap(int?[,] number, Player player)
        {
            Console.Clear();

            for (int i = 0; i < number.GetLength(0); i++)
            {
                for (int j = 0; j < number.GetLength(1); j++)
                {
                    if (number[i, j] == 0)
                    {
                        player.y = i;
                        player.x = j;
                    }
                    Console.Write($" {number[i, j]}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.SetCursorPosition(player.x * 4, player.y * 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('0');
            Console.ResetColor();
        }
    }
}
