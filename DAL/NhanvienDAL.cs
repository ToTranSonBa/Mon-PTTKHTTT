
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;

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

        public PttkNhanvien? GetByID(decimal? ID)
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

        public bool Add(PttkNhanvien nhanVien)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkNhanviens.Add(nhanVien);
                _context.SaveChanges();
                return true;
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
                ModelContext _context = new ModelContext();
                _context.PttkNhanviens.Remove(nhanVien);
                _context.SaveChanges();
                return true;
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
                ModelContext _context = new ModelContext();
                _context.Update<PttkNhanvien>(nhanVien);
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
