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
    public class PhongDAL
    {
        public List<PttkPhong> GetAll()
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
                return _context.PttkPhongs.ToList();
            }
            catch
            {
<<<<<<< HEAD
                return new List<PttkPhong> ();
=======
                return new List<PttkPhong>();
            }
        }

        public PttkPhong? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkPhongs.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkPhong();
            }
        }

        public bool Add(PttkPhong phong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkPhongs.Add(phong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkPhong phong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkPhongs.Remove(phong);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkPhong phong)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkPhong>(phong);
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
