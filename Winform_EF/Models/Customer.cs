using System;
using System.Collections.Generic;

#nullable disable

namespace Winform_EF.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
    }
}
