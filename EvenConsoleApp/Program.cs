using System;
using System.Collections.Generic;

namespace EvenConsoleApp
{
    internal class Program
    {
        static int n;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter number:");
                n = Convert.ToInt32(Console.ReadLine());
            }
            while (n > 10);

            Console.WriteLine("Press any key to submit");
            Console.ReadKey();

            Button btnSubmit = new Button();
            btnSubmit.Name = "Submit";
            // add event listener
            btnSubmit.ButtonClick += BtnSubmit_ButtonClick;

            // event occur
            btnSubmit.Click();
            Console.WriteLine("\nCreating text field");
            foreach(TextField t in list)
                Console.WriteLine("Text: " + t.Text);

            Console.WriteLine("Click any key to add checkbox");

            Button btnAdd = new Button();
            btnAdd.ButtonClick += BtnAdd_ButtonClick;

            btnAdd.Click();

            Console.WriteLine("Checkbox created");
            int i = 0;
            foreach (Checkbox cb in checkboxs)
            {
                i++;
                Console.WriteLine(i + ". " + cb.Name);
            }

            while (true)
            {
                Console.WriteLine("Click to check(Enter 1, 2, 3...):");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 0) break;

                for (i = 0; i < n; i++)
                {
                    if (option - 1 == i)
                    {
                        Console.WriteLine("0. Uncheck");
                        Console.WriteLine("1. Check");
                        Console.WriteLine("Pick one");
                        int c = Convert.ToInt32(Console.ReadLine());

                        checkboxs[i].Checked = (c == 1);
                    }
                }
            }
            int changeTextFieldOption;
            while (true)
            {
                Console.WriteLine("Enter text field number to change(1 -"  + n + " )");
                changeTextFieldOption = Convert.ToInt32(Console.ReadLine());

                if (changeTextFieldOption == 0) break;

                indexChange = changeTextFieldOption - 1;

                for (i = 0; i < n; i++)
                {
                    if (indexChange == i)
                    {
                        Console.WriteLine("Enter text to change");
                        string newText = Console.ReadLine();

                        list[i].Text = newText;
                        Console.WriteLine("New Text:" + list[i].Text);
                        Console.WriteLine("New checkbox name:" + checkboxs[i].Name);
                    }
                }
            }
        }

        static List<TextField> list = new List<TextField>();

        static List<Checkbox> checkboxs = new List<Checkbox>();

        static int indexChange;


        private static void BtnAdd_ButtonClick()
        {
            // Create 'n' Checkbox
            for (int i = 0; i < n; i++)
            {
                Checkbox cb = new Checkbox();
                cb.Name = list[i].Text;
                cb.CheckChange += Cb_CheckChange;
                checkboxs.Add(cb);
            }
        }

        private static void Cb_CheckChange(string text, bool isChecked)
        {
            Console.WriteLine(text + (isChecked ? "checked" : "uncheck"));
        }

        private static void BtnSubmit_ButtonClick()
        {
            // Create 'n' TextField
            for (int i = 0; i < n; i++)
            {
                TextField txt = new TextField();
                Console.WriteLine("Enter text of checkbox");
                txt.Text = Console.ReadLine();
                txt.TextChange += Txt_TextChange;
                list.Add(txt);
            }
        }

        private static void Txt_TextChange(string text)
        {
            checkboxs[indexChange].Name = text;
        }
    }
}
