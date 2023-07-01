using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL
{
    public class LoaiphongDAL
    {
        public List<PttkLoaiphong> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkLoaiphongs.ToList();
            }
            catch
            {
                return new List<PttkLoaiphong>();
            }
        }

        public PttkLoaiphong? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkLoaiphongs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkLoaiphong();
            }
        }

        public bool Add(PttkLoaiphong loaiPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkLoaiphongs.Add(loaiPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkLoaiphong loaiPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkLoaiphongs.Remove(loaiPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkLoaiphong loaiPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkLoaiphong>(loaiPhong);
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
