using DAL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
        public bool Remove(PttkTaikhoan taikhoan)
        {
            try
            {
                TaikhoanDAL _context = new TaikhoanDAL();
                return _context.Remove(taikhoan);
            }
            catch
            {
                return false;
            }
        }
        public PttkTaikhoan? GetByIDemploy(decimal? ID)
        {
            TaikhoanDAL _context = new();
            try
            {
                return _context.GetByID(ID);
            }
            catch
            {
                return new();
            }
        }
        public bool Add(PttkTaikhoan taikhoan)
        {
            try
            {
                PttkTaikhoan pttktaikhoan = taikhoan;
                TaikhoanDAL _context = new TaikhoanDAL();
                return _context.Add(pttktaikhoan);
            }
            catch
            {
                return false;
            }
        }
    }
}
