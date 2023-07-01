using DAL;
using DTO.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;

namespace BUS
{
    public class NhanvienBUS
    {
        public List<PttkNhanvien> GetAll()
        {
            try
            {
                NhanvienDAL _context = new NhanvienDAL();
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkNhanvien> { };
            }
        }

        public PttkNhanvien? GetByID(decimal? ID)
        {
            try
            {
                NhanvienDAL _context = new NhanvienDAL();
                return _context.GetByID(ID);
            }
            catch
            {
                return new PttkNhanvien();
            }
        }
        public bool Add(PttkNhanvien nhanVien)
        {
            try
            {
                PttkNhanvien nhanVien2 = nhanVien;
                nhanVien2.HireDay = DateTime.Now; 
                NhanvienDAL _context = new NhanvienDAL();
                return _context.Add(nhanVien2);
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkNhanvien nhanVien)
        {
            try
            {
                NhanvienDAL _context = new NhanvienDAL();
                return _context.Remove(nhanVien);
            }
            catch
            {
                return false;
            }
        }
        public bool Update(PttkNhanvien nhanVien)
        {
            try
            {
                NhanvienDAL _context = new NhanvienDAL();
                return _context.Update(nhanVien);
            }
            catch
            {
                return false;
            }
        }
    }
}
