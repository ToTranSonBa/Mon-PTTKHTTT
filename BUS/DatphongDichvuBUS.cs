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

        public List<PttkDatphongDichvu> GetAllbyOrderID(decimal? ID)
        {
            DatphongDichvuDAL datphongDichvu = new DatphongDichvuDAL();
            return datphongDichvu.GetAllByOrderID(ID);
        }

        public PttkDatphongDichvu GetOnebyID(decimal? ID)
        {
            DatphongDichvuDAL datphongDichvu = new DatphongDichvuDAL();
            return datphongDichvu.GetByID(ID);
        }
    }
}
