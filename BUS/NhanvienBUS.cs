<<<<<<< HEAD
﻿using DAL;
using DTO.Models;
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
using DAL;
>>>>>>> HoangCau
namespace BUS
{
    public class NhanvienBUS
    {
<<<<<<< HEAD
        public List<PttkNhanvien> GetAll()
        {
            try
            {
                NhanvienDAL _context = new NhanvienDAL();
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkNhanvien> { };
            }
        }

        public PttkNhanvien? GetByID(decimal ID)
        {
            try
            {
                NhanvienDAL _context = new NhanvienDAL();
                return _context.GetByID(ID);
            }
            catch
            {
                return new PttkNhanvien();
            }
        }
=======
>>>>>>> HoangCau
    }
}
