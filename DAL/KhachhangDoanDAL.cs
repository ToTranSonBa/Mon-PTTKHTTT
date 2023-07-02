using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
namespace DAL
{
    public class KhachhangDoanDAL
    {
        public List<PttkKhachhangDoan> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkKhachhangDoans.ToList();
            }
            catch
            {
                return new List<PttkKhachhangDoan>();
            }
        }

        public PttkKhachhangDoan? GetByIDCustomer(decimal? ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkKhachhangDoans.SingleOrDefault(dp => dp.CustomerId == ID);
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
