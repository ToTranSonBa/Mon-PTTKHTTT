using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL
{
    public class DatphongDAL
    {
        public List<PttkDatphong> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDatphongs.ToList();
            }
            catch
            {
                return new List<PttkDatphong>();
            }
        }

        public List<PttkDatphong> getAllPaidRoom()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDatphongs.Where(dp => dp.NgayThanhToan == null).ToList();
            }
            catch
            {
                return new List<PttkDatphong>();
            }
        }

        public PttkDatphong? GetByID(decimal? ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDatphongs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkDatphong();
            }
        }

        public bool Add(PttkDatphong datphong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkDatphongs.Add(datphong);
                _context.SaveChanges();
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkDatphong datphong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkDatphongs.Remove(datphong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkDatphong datphong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkDatphong>(datphong);
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
