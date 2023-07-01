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
    }
}
