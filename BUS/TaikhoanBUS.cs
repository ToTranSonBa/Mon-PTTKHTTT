using DAL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaikhoanBUS
    {
        public List<PttkTaikhoan> GetAll()
        {
            try
            {
                TaikhoanDAL _context = new TaikhoanDAL();
                return _context.GetAll();
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
                TaikhoanDAL _context = new TaikhoanDAL();
                return _context.GetByUsernamePassword(username, password);
            }
            catch
            {
                return new PttkTaikhoan();
            }
        }
    }
}
