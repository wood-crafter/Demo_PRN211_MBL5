using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_PRN211_MBL5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create List to save data
            List<Empoyee> list = new List<Empoyee>();
            IManager manager = new Manager(list);
            manager.loadFile();

            // Create UI
            while (true)
            {
                Console.WriteLine("1. Add to list");
                Console.WriteLine("2. Show list");
                Console.WriteLine("3. Update information");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
                Console.WriteLine("6. Delete employee");
                Console.WriteLine("7. Report");
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
                            manager.saveFile();
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
                            manager.saveFile();
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
                    case 7:
                        {
                            // 1. Display all male
                            Console.WriteLine("Male staff");
                            var result = from emp in list
                                         where emp.Gender == "Male"
                                         select emp;
                            foreach (Empoyee emp in result) Console.WriteLine(emp.ToString());

                            // 2. Display all Security
                            Console.WriteLine("Security");
                            result = list.Where(emp => emp.Role.Trim().ToLower().Equals("security"));
                            foreach (Empoyee emp in result) Console.WriteLine(emp.ToString());

                            // 3. Display number of Female
                            result = list.Where(emp => emp.Gender.Trim().ToLower().Equals("female"));
                            Console.WriteLine("Number of Female: " + result.Count());

                            // 4. Display sum of all director salary
                            result = list.Where(emp => emp.Role.Trim().ToLower().Equals("director"));
                            long sumSalary = 0;
                            foreach (Empoyee emp in result) sumSalary += emp.Salary;
                            Console.WriteLine("Sum of director salary: " + sumSalary);

                            // 5. Sort by salary decreasing
                            Console.WriteLine("Sort by salary");
                            result = list.OrderBy(emp => emp.Salary).Reverse();
                            foreach (Empoyee emp in result) Console.WriteLine(emp.ToString());

                            // 6. Sort by Gender decreasing and salary acending
                            Console.WriteLine("Sort by gender:");
                            result = list.OrderBy(emp => emp.Gender).ThenBy(emp => -emp.Salary).Reverse();
                            foreach (Empoyee emp in result) Console.WriteLine(emp.ToString());

                            // 7. Sort by firstName length decreasing Male
                            Console.WriteLine("firstName length decreasing Male: ");
                            int maxLength = list.Max(emp => getFirstNameLenght(emp.Name));
                            result = list.Where(emp => getFirstNameLenght(emp.Name) == maxLength);
                            foreach (Empoyee emp in result) Console.WriteLine(emp.ToString());
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter option as above(1-7)");
                            break;
                        }
                }
            }

        }

        static int getFirstNameLenght(string name)
        {
            string[] nameArray = name.Trim().Split(" ");
            return nameArray[nameArray.Length - 1].Length;
        }
    }
}
