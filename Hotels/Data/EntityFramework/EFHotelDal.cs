using Data.Abstract;
using Data.Concreate;
using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework
{
    public class EFHotelDal : GenericRepository<Hotel>, IHotelDal
    {
    }
}
