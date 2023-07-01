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
                KhachhangDAL khachhangDAL = new KhachhangDAL();
                return khachhangDAL.GetAll();
            }
            catch
            {
                return new List<PttkKhachhang>();
            }
        }

        public PttkKhachhang? GetByID(decimal ID)
        {
            KhachhangDAL khachhangDAL = new KhachhangDAL();
            try
            {
                return khachhangDAL.GetByID(ID);
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
                KhachhangDAL khachhangDAL = new KhachhangDAL();
                khachhangDAL.Add(khachHang);
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
                KhachhangDAL khachhangDAL = new KhachhangDAL();
                khachhangDAL.Remove(khachHang);
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
