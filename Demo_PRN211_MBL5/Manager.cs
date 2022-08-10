using System;
using System.Collections.Generic;
using System.IO;

namespace Demo_PRN211_MBL5
{
    internal class Manager : IManager
    {
        private List<Empoyee> list;

        public Manager(List<Empoyee> list)
        {
            this.list = list;
        }

        public void addList(int index)
        {
            string code = "";
            string name = "";
            bool isMale = true;
            string role = "Director";
            long salary = 10000000;
            bool isValid = true;

            if (index == -1)
            {
                while (isValid)
                {
                    isValid = false;
                    Console.WriteLine("Enter code");
                    code = Console.ReadLine();
                    if (isCodeExisted(code) == -1)
                    {
                        break;
                    }

                    Console.WriteLine("Duplicate code");
                }
            }

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

            if (index == -1)
            {
                list.Add(new Empoyee(code, name, isMale, role, salary));
            }
            else
            {
                list[index] = new Empoyee(list[index].Code, name, isMale, role, salary);
            }
        }

        public void showEmployee()
        {
            foreach (Empoyee empoyee in list)
            {
                Console.WriteLine(empoyee.ToString());
            }
        }

        public void updateList()
        {
            string code;
            int index;
            while (true)
            {
                Console.WriteLine("Enter code");
                code = Console.ReadLine();
                index = isCodeExisted(code);

                if (index == -1)
                {
                    continue;
                }

                addList(index);
                break;
            }
        }

        public int isCodeExisted(string code)
        {
            foreach (Empoyee empoyee in list)
            {
                if (empoyee.Code == code)
                {
                    return list.IndexOf(empoyee);
                }
            }

            return -1;
        }

        public void delete()
        {
            string code;
            int index;
            while (true)
            {
                Console.WriteLine("Enter code");
                code = Console.ReadLine();
                index = isCodeExisted(code);

                if (index == -1)
                {
                    continue;
                }

                list.RemoveAt(index);

                break;
            }
        }

        public void saveFile()
        {
            try
            {
                string filename = @"..\..\..\data.txt";
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach(Empoyee empoyee in list)
                    {
                        sw.WriteLine(empoyee.ToString());
                    }
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Save error:" + ex.Message);
            }
        }

        public void loadFile()
        {
            list.Clear();
            try
            {
                string filename = @"..\..\..\data.txt";
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (String.IsNullOrEmpty(line)) continue;
                        string[] arrayEmployee = line.Split("\t");
                        bool isMale = arrayEmployee[2] == "Male";
                        Empoyee newEmp = new Empoyee(arrayEmployee[0], arrayEmployee[1], isMale, arrayEmployee[3], Convert.ToInt32(arrayEmployee[4]));
                        list.Add(newEmp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load error:" + ex.Message);
            }
        }
    }
}