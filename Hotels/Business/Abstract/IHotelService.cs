using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHotelService
    {
        List<Hotel> Hotelliste();
        void HotelInsert(Hotel h);
        void HotelUpdate(Hotel h);
        void HotelDelete(Hotel h );
        Hotel GetById(int id);
    }
}
