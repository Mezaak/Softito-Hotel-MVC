using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public bool IsAdmin { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
