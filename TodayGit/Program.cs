namespace TodayGit
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
    }
}