using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concreate
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        Context db = new Context();
        DbSet<T> _obj;

        public GenericRepository()
        {
            _obj = db.Set<T>();
        }

        public void Delete(T entity)
        {
            var sonuc = db.Entry(entity);
            sonuc.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return _obj.Find(id);
        }

        public void Insert(T entity)
        {
            var sonuc = db.Entry(entity);
            sonuc.State = EntityState.Added;
            db.SaveChanges();
        }

        public List<T> liste()
        {
            return _obj.ToList();
        }

        public void Update(T entity)
        {
            var sonuc = db.Entry(entity);
            sonuc.State = EntityState.Modified;
            db.SaveChanges();
        }

        public T GetCustomer()
        {
            return _obj.FirstOrDefault();
        }

        //public void SaveChanges()
        //{
        //    _obj.FirstOrDefault();
        //}

        
    }
}
