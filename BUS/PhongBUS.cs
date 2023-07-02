using DAL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;

namespace BUS
{
    public class PhongBUS
    {

        public List<PttkPhong> GetAll()
        {
            PhongDAL phongDAL = new PhongDAL();
            return phongDAL.GetAll();
        }
        public PttkPhong GetById(decimal? id)
        {
            PhongDAL phongDAL = new PhongDAL();
            return phongDAL.GetByID(id);
        }
        public bool Add(PttkPhong khachHang)
        {
            try
            {
                PhongDAL _context = new PhongDAL();
                _context.Add(khachHang);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkPhong khachHang)
        {
            try
            {
                PhongDAL _context = new PhongDAL();
                _context.Remove(khachHang);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

        public bool Update(PttkPhong phong)
        {
            try
            {
                PhongDAL phongDAL = new PhongDAL();
                return phongDAL.Update(phong);
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkPhong khachHang)
        {
            try
            {
                PhongDAL _context = new PhongDAL();
                _context.Remove(khachHang);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    
}
