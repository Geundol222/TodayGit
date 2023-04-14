﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayGit
{
    internal class Bingo
    {
        static void GameStart()
        {
            string[,] Bingo = RenderNumber();
            int count = 0;

            Console.WriteLine("빙고게임을 시작합니다.");
            Console.WriteLine("1 ~ 25의 숫자를 입력해주십시오. : ");


            while (true)
            {
                Console.Clear();
                int input = int.Parse(Console.ReadLine());
                if (input > 25 || input < 0)
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                }

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (Bingo[i, j] == input.ToString())
                        {
                            Bingo[i, j] = "#";
                        }
                    }
                }
            }

        }

        static int BingoClear(string[,] Bingo)
        {
            int bCount = 0;
            string[] clear = new string[5];

            int countCross1 = 0;
            int countCross2 = 0;

            for (int i = 0; i < 5; i++)
            {
                int countCal = 0;
                int countRow = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (Bingo[i, j] == "#")
                        countRow++;
                    if (Bingo[j, i] == "#")
                        countCal++;
                    if (i == j && Bingo[i, j] == "#")
                        countCross1++;
                    if ((i + j == 4) && Bingo[i, j] == "#")
                        countCross2++;
                }
                if (countRow == 5)
                    bCount++;
                if (countCal == 5)
                    bCount++;
            }

            if (countCross1 == 5)
                bCount++;
            if (countCross2 == 5)
                bCount++;

            return bCount;
        }


        static string[,] RenderNumber()
        {
            Random rand = new Random();
            string[] num = new string[25];
            string[,] Bingo = new string[5, 5];
            int index = 0;

            for (int i = 0; i < num.Length; i++)
            {
                num[i] = rand.Next(1, 26).ToString();
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
                    Bingo[i, j] = num[index++];
                }
            }

            for (int i = 0; i < Bingo.GetLength(0); i++)
            {
                for (int j = 0; j < Bingo.GetLength(1); j++)
                {
                    Console.Write($" {Bingo[i, j]}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            return Bingo;
        }

    }
}
