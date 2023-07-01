using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;

namespace BUS
{
    public class LoaiphongBUS
    {
        public List<PttkLoaiphong> GetAll()
        {
            LoaiphongDAL _context = new LoaiphongDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkLoaiphong>();
            }
        }
        public PttkLoaiphong? GetByID(decimal? ID)
        {
            LoaiphongDAL loaiphongDAL = new LoaiphongDAL();
            return loaiphongDAL.GetByID(ID);
        }

    }
}
