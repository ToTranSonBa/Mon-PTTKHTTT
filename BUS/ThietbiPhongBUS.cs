using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;
namespace BUS
{
    public class ThietbiPhongBUS
    {
        public List<PttkThietbiPhong> GetAll()
        {
            ThietbiPhongDAL _context = new ThietbiPhongDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkThietbiPhong>();
            }
        }

        public PttkThietbiPhong? GetByID(decimal ID)
        {
            ThietbiPhongDAL _context = new ThietbiPhongDAL();
            try
            {
                return _context.GetByID(ID);
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
                ThietbiPhongDAL _context = new ThietbiPhongDAL();
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
    }
}
