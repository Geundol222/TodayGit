﻿namespace TodayGit
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }

        static void FindWord()
        {
            string str = Console.ReadLine();
            string str2 = Console.ReadLine();
            int? result = str.IndexOf(str2);

            if (result == null)
                result = -1;

            Console.WriteLine(result);
        }

        static void WordCount()
        {
            string str = Console.ReadLine();
            string[] strArray = str.Split(' ');

            Console.WriteLine(strArray.Length);
        }

        static bool IsPrime(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            foreach (int index in arr)
            {
                if (n % index == 0 && index != 1 && index != n)
                    return false;
            }
            return true;
        }
    }
}