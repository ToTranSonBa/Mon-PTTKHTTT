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
    public class NhanvienDAL
    {
        public List<PttkNhanvien> GetAll()
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
                return _context.PttkNhanviens.ToList();
            }
            catch
            {
<<<<<<< HEAD
                return new List<PttkNhanvien> { };
=======
                return new List<PttkNhanvien>();
>>>>>>> HoangCau
            }
        }

        public PttkNhanvien? GetByID(decimal ID)
        {
<<<<<<< HEAD
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkNhanviens.SingleOrDefault((nv => nv.Id == ID));
=======
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkNhanviens.SingleOrDefault(dp => dp.Id == ID);
>>>>>>> HoangCau
            }
            catch
            {
                return new PttkNhanvien();
            }
        }
<<<<<<< HEAD
=======

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
>>>>>>> HoangCau
    }
}
