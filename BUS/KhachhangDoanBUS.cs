using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;

namespace BUS
{
    public class KhachhangDoanBUS
    {
        public List<PttkKhachhangDoan> GetAll()
        {
            KhachhangDoanDAL _context = new KhachhangDoanDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkKhachhangDoan>();
            }
        }

        public PttkKhachhangDoan? GetByIDCustomer(decimal? ID)
        {
            KhachhangDoanDAL _context = new KhachhangDoanDAL();
            try
            {
                return _context.GetByIDCustomer(ID);
            }
            catch
            {
                return new PttkKhachhangDoan();
            }
        }

        public bool Add(PttkKhachhangDoan khachhangDoan)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkKhachhangDoans.Add(khachhangDoan);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkKhachhangDoan khachhangDoan)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkKhachhangDoans.Remove(khachhangDoan);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkKhachhangDoan khachhangDoan)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkKhachhangDoan>(khachhangDoan);
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
