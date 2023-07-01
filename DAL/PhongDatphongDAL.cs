using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace DAL
{
    internal class PhongDatphongDAL
    {
=======
using DTO.Models;

namespace DAL
{
    public class PhongDatphongDAL
    {
        public List<PttkPhongDatphong> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkPhongDatphongs.ToList();
            }
            catch
            {
                return new List<PttkPhongDatphong>();
            }
        }

        public PttkPhongDatphong? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkPhongDatphongs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkPhongDatphong();
            }
        }

        public bool Add(PttkPhongDatphong phongDatPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkPhongDatphongs.Add(phongDatPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkPhongDatphong phongDatPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkPhongDatphongs.Remove(phongDatPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkPhongDatphong phongDatPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkPhongDatphong>(phongDatPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
>>>>>>> HoangCau
    }
}
