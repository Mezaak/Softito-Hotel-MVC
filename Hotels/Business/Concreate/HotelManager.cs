using Business.Abstract;
using Data.Abstract;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class HotelManager:IHotelService
    {
        IHotelDal _hotelDal;

        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }

        public Hotel GetById(int id)
        {
            return _hotelDal.GetById(id);
          
        }

        public void HotelDelete(Hotel h)
        {
            _hotelDal.Delete(h);
        }

        public void HotelInsert(Hotel h)
        {
            _hotelDal.Insert(h);
        }

        public List<Hotel> Hotelliste()
        {
           return _hotelDal.liste();
        }

        public void HotelUpdate(Hotel h)
        {
            _hotelDal.Update(h);
        }
    }
}
