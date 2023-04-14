namespace TodayGit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int result = SumOfDigit(num);
            Console.WriteLine(result);

            UpDownGame();
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

        static int SumOfDigit(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result += num % 10;
                num /= 10;
            }

            return result;
        }

        static void UpDownGame()
        {
            Random rand = new Random();

            int com = rand.Next(0, 1000);
            int count = 10;

            while (true)
            {
                if (count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("도전횟수 초과! 패배했습니다.");
                    Console.WriteLine("다시 하시겠습니까?");
                    Console.WriteLine("[1] 예");
                    Console.WriteLine("[2] 아니오");
                    string restart = Console.ReadLine();

                    if (restart == "1")
                    {
                        count = 10;
                        com = rand.Next(0, 1000);
                        continue;
                    }
                    else
                        break;
                }

                Console.Clear();
                Console.WriteLine($"도전횟수{count}");
                Console.Write("숫자를 입력하세요(0 ~ 999) : ");
                int input = int.Parse(Console.ReadLine());

                if (input > 999 || input < 0)
                {
                    Console.WriteLine("error : 0에서 999사이의 값을 입력하세요");
                    Console.WriteLine("계속하려면 아무키나 누르십시오");
                    Console.ReadKey();
                    continue;
                }
                else if (input > com)
                {
                    count--;
                    Console.WriteLine("Down");
                    Console.WriteLine("계속하려면 아무키나 누르십시오");
                    Console.ReadKey();
                    continue;
                }
                else if (input < com)
                {
                    count--;
                    Console.WriteLine("Up");
                    Console.WriteLine("계속하려면 아무키나 누르십시오");
                    Console.ReadKey();
                    continue;
                }
                else if (input == com)
                {
                    Console.WriteLine("정답입니다!");
                    Console.WriteLine("다시 하시겠습니까?");
                    Console.WriteLine("[1] 예");
                    Console.WriteLine("[2] 아니오");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        count = 10;
                        com = rand.Next(0, 1000);
                        continue;
                    }
                    else
                        break;
                }

            }
        }

    }
}