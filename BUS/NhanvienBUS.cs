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
    }
}
