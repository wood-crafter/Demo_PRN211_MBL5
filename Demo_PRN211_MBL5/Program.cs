using System;

namespace Demo_PRN211_MBL5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create UI
            while (true)
            {
                Console.WriteLine("1. Add to list");
                Console.WriteLine("2. Show list");
                Console.WriteLine("1. Update information");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option");

                int option = Convert.ToInt32(Console.ReadLine());
            }

        }
    }
}
