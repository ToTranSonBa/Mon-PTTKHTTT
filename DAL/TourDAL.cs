using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;


namespace DAL
{
    public class TourDAL
    {
        public List<PttkTour> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkTours.ToList();
            }
            catch
            {
                return new List<PttkTour>();
            }
        }

        public PttkTour? GetByID(decimal ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkTours.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkTour();
            }
        }

        public bool Add(PttkTour tour)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkTours.Add(tour);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkTour tour)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkTours.Remove(tour);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkTour tour)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.Update<PttkTour>(tour);
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
