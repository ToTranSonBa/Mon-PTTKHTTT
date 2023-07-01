using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;

namespace BUS
{
    public class DichvuBUS
    {
        public List<PttkDichvu> GetAll()
        {
            DichvuDAL _context = new DichvuDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkDichvu>();
            }
        }

        public PttkDichvu? GetByID(decimal? ID)
        {
            DichvuDAL _context = new DichvuDAL();
            try
            {
                return _context.GetByID(ID);
            }
            catch
            {
                return new PttkDichvu();
            }
        }

        public bool Add(PttkDichvu dichVu)
        {
            try
            {
                DichvuDAL _context = new DichvuDAL();

                _context.Add(dichVu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkDichvu dichVu)
        {
            try
            {
                DichvuDAL _context = new DichvuDAL();

                _context.Remove(dichVu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkDichvu dichVu)
        {
            try
            {
                DichvuDAL _context = new DichvuDAL();

                _context.Update(dichVu);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
