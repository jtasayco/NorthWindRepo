using NorthWind.DAO;
using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Logic
{
    public class TbClienteBL
    {
        public static List<TbClienteBE> SelectAll()
        {
            return TbClienteDao.SelectAll();
        }
    }
}
