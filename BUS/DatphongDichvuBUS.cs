using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;

namespace BUS
{
    public class DatphongDichvuBUS
    {
        public List<PttkDatphongDichvu> GetAll()
        {
            DatphongDichvuDAL datphongDichvuDAL = new DatphongDichvuDAL();
            return datphongDichvuDAL.GetAll();
        }
    }
}
