using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachhangDAL
    {
        public List<PttkKhachhang> GetAll()
        {
            try
            {
                ModelContext _context = new ModelContext();
                return _context.PttkKhachhangs.ToList();
            }
            catch
            {
                return new List<PttkKhachhang> ();
            }
        }
    }
}
