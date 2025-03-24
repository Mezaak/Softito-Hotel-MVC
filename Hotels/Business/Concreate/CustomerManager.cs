using Business.Abstract;
using Data.Abstract;
using Data.Concreate;
using Data.EntityFramework;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;
        Context _db;

        public CustomerManager(ICustomerDal customerDal, Context context)
        {
            _customerDal = customerDal;
            _db = context;
        }
        public void CustomerDelete(Customer c)
        {
            _customerDal.Delete(c);
        }

        public void CustomerInsert(Customer c)
        {
            _customerDal.Insert(c);
        }

        public List<Customer> Customerliste()
        {
            return _customerDal.liste();
        }

        public void CustomerUpdate(Customer c)
        {
            _customerDal.Update(c);
        }

        public Customer GetById(int id)
        {
           return _customerDal.GetById(id);
        }

        public Customer GetCustomer()
        {
            return _customerDal.GetCustomer();
        }

        //public void SaveChanges()
        //{
        //    _db.SaveChanges();
        //}
    }
}
