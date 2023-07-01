using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;
namespace BUS
{
    public class ThietbiBUS
    {
        public List<PttkThietbi> GetAll()
        {
            ThietbiDAL _context = new ThietbiDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkThietbi>();
            }
        }

        public PttkThietbi? GetByID(decimal? ID)
        {
            ThietbiDAL _context = new ThietbiDAL();
            try
            {
                return _context.GetByID(ID);
            }
            catch
            {
                return new PttkThietbi();
            }
        }

        public bool Add(PttkThietbi thietBi)
        {
            try
            {
                ThietbiDAL _context = new ThietbiDAL();
                _context.Add(thietBi);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkThietbi thietBi)
        {
            try
            {
                ThietbiDAL _context = new ThietbiDAL();
                _context.Remove(thietBi);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkThietbi thietBi)
        {
            try
            {
                ThietbiDAL _context = new ThietbiDAL();
                _context.Update(thietBi);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
