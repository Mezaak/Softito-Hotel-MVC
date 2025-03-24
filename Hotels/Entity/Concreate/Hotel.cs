using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Hotel
    {
        public int HotelID { get; set; }

        public string HotelTopic { get; set; }

        public string HotelDescription { get; set; }

        public string HotelPhoto { get; set; }

        public int HotelPrice { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
