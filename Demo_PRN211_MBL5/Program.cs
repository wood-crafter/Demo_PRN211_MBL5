﻿using System;
using System.Collections.Generic;

namespace Demo_PRN211_MBL5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create List to save data
            List<Empoyee> list = new List<Empoyee>();

            // Create UI
            while (true)
            {
                Console.WriteLine("1. Add to list");
                Console.WriteLine("2. Show list");
                Console.WriteLine("1. Update information");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
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
                            addList(list);
                            break;
                        }
                    case 2:
                        {
                            showEmployee(list);
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
                    default:
                        {
                            Console.WriteLine("Please enter option as above(1-6)");
                            break;
                        }
                }
            }

        }

        private static void showEmployee(List<Empoyee> list)
        {
            foreach(Empoyee empoyee in list)
            {
                Console.WriteLine(empoyee.ToString());
            }
        }

        private static void addList(List<Empoyee> list)
        {
            string code;
            string name;
            bool isMale;
            string role = "Director";
            long salary = 10000000;

            Console.WriteLine("Enter code");
            code = Console.ReadLine();

            Console.WriteLine("Enter name");
            name = Console.ReadLine();

            Console.WriteLine("Enter gender");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            int option = Convert.ToInt32(Console.ReadLine());
            isMale = option == 1;

            Console.WriteLine("Enter role");
            Console.WriteLine("1. Director");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Security");
            option = Convert.ToInt32(Console.ReadLine());

            if (option == 2)
            {
                role = "Employee";
                salary = 6000000;
            }

            if (option == 3)
            {
                role = "Security";
                salary = 4000000;
            }
            list.Add(new Empoyee(code, name, isMale, role, salary));
        }
    }
}
