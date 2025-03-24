using Business.Abstract;
using Data.Abstract;
using Data.EntityFramework;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class OrderManager:IOrderService
    {
        IOrderDal _dal;

        public OrderManager(IOrderDal dal)
        {
            _dal = dal;
        }

        public Order GetById(int id)
        {
            return _dal.GetById(id);
        }

        public void OrderDelete(Order h)
        {
            _dal.Delete(h);
        }

        public void OrderInsert(Order h)
        {
            _dal.Insert(h);
        }

        public List<Order> Orderliste()
        {
           return _dal.liste();
        }

        public void OrderUpdate(Order h)
        {
           _dal.Update(h);
        }
    }
}
