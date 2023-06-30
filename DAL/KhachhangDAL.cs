using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL
{
    public class KhachhangDAL
    {
        public List<PttkKhachhang> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkKhachhangs.ToList();
            }
            catch
            {
                return new List<PttkKhachhang>();
            }
        }

        public PttkKhachhang? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkKhachhangs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkKhachhang();
            }
        }

        public bool Add(PttkKhachhang khachHang)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkKhachhangs.Add(khachHang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkKhachhang khachHang)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkKhachhangs.Remove(khachHang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkKhachhang khachHang)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkKhachhang>(khachHang);
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
