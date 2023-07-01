using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;

namespace DAL
{
    public class ThietbiDAL
    {
        public List<PttkThietbi> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkThietbis.ToList();
            }
            catch
            {
                return new List<PttkThietbi>();
            }
        }

        public PttkThietbi? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkThietbis.SingleOrDefault(dp => dp.Id == ID);
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
                ModelContext _context = new ModelContext();
                _context.PttkThietbis.Add(thietBi);
                _context.SaveChanges();
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
                ModelContext _context = new ModelContext();
                _context.PttkThietbis.Remove(thietBi);
                _context.SaveChanges();
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
                ModelContext _context = new ModelContext();
                _context.Update<PttkThietbi>(thietBi);
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
