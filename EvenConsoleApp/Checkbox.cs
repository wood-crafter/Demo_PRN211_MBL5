using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenConsoleApp
{
    internal class Checkbox
    {
        public delegate void handle(string text, bool isChecked);
        public event handle CheckChange;
        public string Name { get; set; }

        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            set 
            { 
                // event occur
                if (value != _checked)
                {
                    if (CheckChange != null)
                    {
                        CheckChange(Name, value);
                    }
                }
                _checked = value; 
            }
        }

    }
}
