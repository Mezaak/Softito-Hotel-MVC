using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Order
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public int OrderId { get; set; }
        public int AdultCount { get; set; }

        public int KidCount { get; set; }
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        // Her Order bir Hotel'e ait olmalı
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public int CustomerId { get; set; }
    }
      
}
