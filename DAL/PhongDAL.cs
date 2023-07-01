using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return new List<PttkPhong> ();
            }
        }
    }
}
