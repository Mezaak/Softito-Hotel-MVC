using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> Orderliste();
        void OrderInsert(Order h);
        void OrderUpdate(Order h);
        void OrderDelete(Order h);
        Order GetById(int id);
    }
}
