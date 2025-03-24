using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concreate
{
    public class Context:DbContext
    {
        DbSet<Customer> Customers {  get; set; }
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}
