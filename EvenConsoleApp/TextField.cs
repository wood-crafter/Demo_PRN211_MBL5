using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenConsoleApp
{
    public class TextField
    {
        public delegate void handle(string text);
        public event handle TextChange;

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                if(_text == null)
                {
                    _text = value;
                    return;
                }
                // event occur
                if (!value.Equals(_text))
                {
                    if (TextChange != null)
                    {
                        TextChange(value);
                    }
                    _text = value;
                } else
                {
                    Console.WriteLine("Text was same");
                }
            }
        }

    }
}
