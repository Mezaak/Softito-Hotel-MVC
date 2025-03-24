using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> Customerliste();
        void CustomerInsert(Customer c);
        void CustomerUpdate(Customer c);
        void CustomerDelete(Customer c);
        Customer GetById(int id);
        Customer GetCustomer();
        //void SaveChanges();
    }
}
