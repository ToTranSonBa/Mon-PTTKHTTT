
﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;


namespace DAL
{
    public class PhongDAL
    {
        public List<PttkPhong> GetAll()
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkPhongs.ToList();
            }
            catch
            {
                return new List<PttkPhong>();
            }
        }

        public PttkPhong? GetByID(decimal? ID)
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
                _context.PttkPhongs.Add(new PttkPhong
                {
                    HygieneStatus = phong.HygieneStatus,
                    Kind = phong.Kind,
                    RoomNumber = phong.RoomNumber,
                    Price = phong.Price,
                    RentStatus = phong.RentStatus,

                });
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
            }
        }
    }
}
