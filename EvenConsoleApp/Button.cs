using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenConsoleApp
{
    public class Button
    {
        public string Name { get; set; }

        // Design event

        public delegate void handle();
        // Create event
        public event handle ButtonClick;

        internal void Click()
        {
            // if Click event have had handler
            if (ButtonClick != null)
            {
                ButtonClick();
            }
        }
    }
}
