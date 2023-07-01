using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace DAL
{
    internal class ThietbiPhongDAL
    {
=======
using DTO.Models;

namespace DAL
{
    public class ThietbiPhongDAL
    {
        public List<PttkThietbiPhong> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkThietbiPhongs.ToList();
            }
            catch
            {
                return new List<PttkThietbiPhong>();
            }
        }

        public PttkThietbiPhong? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkThietbiPhongs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkThietbiPhong();
            }
        }

        public bool Add(PttkThietbiPhong thietBiPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkThietbiPhongs.Add(thietBiPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkThietbiPhong thietBiPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkThietbiPhongs.Remove(thietBiPhong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkThietbiPhong thietBiPhong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkThietbiPhong>(thietBiPhong);
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
