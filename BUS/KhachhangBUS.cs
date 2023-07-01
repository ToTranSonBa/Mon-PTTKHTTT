using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;

namespace BUS
{
    public class KhachhangBUS
    {
        public List<PttkKhachhang> GetAll()
        {
            try
            {
                KhachhangDAL _context = new KhachhangDAL();
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkKhachhang>();
            }
        }

        public PttkKhachhang? GetByID(decimal? ID)
        {
            KhachhangDAL _context = new KhachhangDAL();
            try
            {
                return _context.GetByID(ID);
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
                KhachhangDAL _context = new KhachhangDAL();
                _context.Add(khachHang);
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
                KhachhangDAL _context = new KhachhangDAL();
                _context.Remove(khachHang);
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
