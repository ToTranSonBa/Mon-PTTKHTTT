using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL
{
    public class QuydinhDAL
    {
        public List<PttkQuydinh> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkQuydinhs.ToList();
            }
            catch
            {
                return new List<PttkQuydinh>();
            }
        }
    }
}
