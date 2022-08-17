using System;
using System.Collections.Generic;

#nullable disable

namespace Winform_EF.Models
{
    public partial class User
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
    }
}
