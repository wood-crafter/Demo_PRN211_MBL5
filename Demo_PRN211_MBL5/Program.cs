using System;
using System.Collections.Generic;

namespace Demo_PRN211_MBL5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create UI
            while (true)
            {
                // Create List to save data
                List<Empoyee> list = new List<Empoyee>();

                Console.WriteLine("1. Add to list");
                Console.WriteLine("2. Show list");
                Console.WriteLine("1. Update information");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter option as above(1-6)");
                            break;
                        }
                }
            }

        }
    }
}
