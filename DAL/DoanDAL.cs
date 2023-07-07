﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
namespace DAL
{
    public class DoanDAL
    {
        public List<PttkDoan> GetAll()
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDoans.ToList();
            }
            catch
            {
                return new List<PttkDoan>();
            }
        }

        public PttkDoan? GetByID(decimal? ID)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDoans.SingleOrDefault(dp => dp.Id == ID);
            }
            catch
            {
                return new PttkDoan();
            }
        }

        public PttkDoan? GetByName(string name)
        {
            ModelContext _context = new ModelContext();
            try
            {
                return _context.PttkDoans.SingleOrDefault(dp => dp.Name == name);
            }
            catch
            {
                return new PttkDoan();
            }
        }

        public bool Add(PttkDoan doan)
        {
            try
            {
                ModelContext _context = new ModelContext();
                _context.PttkDoans.Add(doan);
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
