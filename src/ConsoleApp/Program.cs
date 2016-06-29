using static System.Console;
using Ataoge.SafSystem;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 29;
            WriteLine($"The answer is {new Thing().Get(i, 23)}");
        }
    }
}
