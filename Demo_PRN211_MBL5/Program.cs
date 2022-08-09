using System;
using System.Collections.Generic;

namespace Demo_PRN211_MBL5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create List to save data
            List<Empoyee> list = new List<Empoyee>();
            IManager manager = new Manager(list);

            // Create UI
            while (true)
            {
                Console.WriteLine("1. Add to list");
                Console.WriteLine("2. Show list");
                Console.WriteLine("3. Update information");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
                Console.WriteLine("6. Delete employee");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose an option");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        {
                            Console.WriteLine("Bye");
                            break;
                        }
                    case 1:
                        {
                            manager.addList(-1);
                            break;
                        }
                    case 2:
                        {
                            manager.showEmployee();
                            break;
                        }
                    case 3:
                        {
                            manager.updateList();
                            break;
                        }
                    case 4:
                        {
                            manager.saveFile();
                            break;
                        }
                    case 5:
                        {
                            manager.loadFile();
                            break;
                        }
                    case 6:
                        {
                            manager.delete();
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
