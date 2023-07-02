using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaikhoanDAL
    {
        public List<PttkTaikhoan> GetAll()
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkTaikhoans.ToList();
            }
            catch
            {
                return new List<PttkTaikhoan>();
            }
        }
        public PttkTaikhoan? GetByUsernamePassword(string username, string password)
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkTaikhoans.SingleOrDefault(tk => tk.Name == username && tk.Password == password);
            }
            catch
            {
                return new PttkTaikhoan();
            }
        }
        public bool Remove(PttkTaikhoan taikhoan)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkTaikhoans.Remove(taikhoan);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PttkTaikhoan? GetByID(decimal? ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkTaikhoans.SingleOrDefault(dp => dp.EmployeeId == ID);
            }
            catch
            {
                return new ();
            }
        }
        public bool Add(PttkTaikhoan taikhoan)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkTaikhoans.Add(taikhoan);
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
