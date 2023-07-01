using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace DAL
{
    internal class TourKhachhangDAL
    {
=======
using DTO.Models;

namespace DAL
{
    public class TourKhachhangDAL
    {
        public List<PttkTourKhachhang> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkTourKhachhangs.ToList();
            }
            catch
            {
                return new List<PttkTourKhachhang>();
            }
        }

        public PttkTourKhachhang? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkTourKhachhangs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkTourKhachhang();
            }
        }

        public bool Add(PttkTourKhachhang tourKhachHang)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkTourKhachhangs.Add(tourKhachHang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkTourKhachhang tourKhachHang)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkTourKhachhangs.Remove(tourKhachHang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkTourKhachhang tourKhachHang)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkTourKhachhang>(tourKhachHang);
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
