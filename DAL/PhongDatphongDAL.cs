using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public PttkPhongDatphong? getOneByRoomID(decimal? ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                //DateTime dateTime = DateTime.Now;
                DateTime dateTime = new DateTime(2022, 6, 21);

                return _context.PttkPhongDatphongs.Where(t => t.RoomId == ID ).ToList().OrderByDescending(t => t.Id).FirstOrDefault();
            }
            catch
            {
                return new PttkPhongDatphong();
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

        public List<PttkPhongDatphong> GetByOrderID(decimal? ID)
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkPhongDatphongs.Where(item => item.OrderId == ID).ToList();
            }
            catch
            {
                return new List<PttkPhongDatphong>();
            }
        }

        public PttkPhongDatphong? GetByPhongIDAndDatphongID(decimal? phong, decimal? datphong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkPhongDatphongs.SingleOrDefault(a => a.RoomId == phong && a.OrderId == datphong);
            }
            catch
            {
                return null;
            }
        }
    }
}
