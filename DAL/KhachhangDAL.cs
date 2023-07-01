<<<<<<< HEAD
﻿using DTO.Models;
using System;
=======
﻿using System;
>>>>>>> HoangCau
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using DTO.Models;
>>>>>>> HoangCau

namespace DAL
{
    public class KhachhangDAL
    {
        public List<PttkKhachhang> GetAll()
        {
<<<<<<< HEAD
            try
            {
                ModelContext _context = new ModelContext();
=======
            ModelContext _context = new ModelContext();
            try
            {
>>>>>>> HoangCau
                return _context.PttkKhachhangs.ToList();
            }
            catch
            {
<<<<<<< HEAD
                return new List<PttkKhachhang> ();
=======
                return new List<PttkKhachhang>();
            }
        }

        public PttkKhachhang? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkKhachhangs.SingleOrDefault(dp => dp.Id == ID);
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
                ModelContext _context = new ModelContext();
                _context.PttkKhachhangs.Add(khachHang);
                _context.SaveChanges();
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
                ModelContext _context = new ModelContext();
                _context.PttkKhachhangs.Remove(khachHang);
                _context.SaveChanges();
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
>>>>>>> HoangCau
            }
        }
    }
}
