using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace DAL
{
    internal class DichvuDAL
    {
=======
using DTO.Models;

namespace DAL
{
    public class DichvuDAL
    {
        public List<PttkDichvu> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDichvus.ToList();
            }
            catch
            {
                return new List<PttkDichvu>();
            }
        }

        public PttkDichvu? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDichvus.SingleOrDefault(dp => dp.Id == ID);
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
                ModelContext _context = new ModelContext();
                _context.PttkDichvus.Add(dichVu);
                _context.SaveChanges();
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
                ModelContext _context = new ModelContext();
                _context.PttkDichvus.Remove(dichVu);
                _context.SaveChanges();
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
                ModelContext _context = new ModelContext();
                _context.Update<PttkDichvu>(dichVu);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
>>>>>>> HoangCau
    }
}
