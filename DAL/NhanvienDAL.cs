using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanvienDAL
    {
        public List<PttkNhanvien> GetAll()
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkNhanviens.ToList();
            }
            catch
            {
                return new List<PttkNhanvien> { };
            }
        }

        public PttkNhanvien? GetByID(decimal ID)
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkNhanviens.SingleOrDefault((nv => nv.Id == ID));
            }
            catch
            {
                return new PttkNhanvien();
            }
        }
    }
}
