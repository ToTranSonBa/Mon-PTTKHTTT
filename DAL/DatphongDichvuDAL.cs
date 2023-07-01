using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;

namespace DAL
{
    public class DatphongDichvuDAL
    {
        public List<PttkDatphongDichvu> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDatphongDichvus.ToList();
            }
            catch
            {
                return new List<PttkDatphongDichvu>();
            }
        }

        public PttkDatphongDichvu? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDatphongDichvus.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkDatphongDichvu();
            }
        }

        public bool Add(PttkDatphongDichvu datPhongDichVu)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkDatphongDichvus.Add(datPhongDichVu);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkDatphongDichvu datPhongDichVu)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkDatphongDichvus.Remove(datPhongDichVu);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkDatphongDichvu datPhongDichVu)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkDatphongDichvu>(datPhongDichVu);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
