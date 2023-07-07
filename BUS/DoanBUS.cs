using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;

namespace BUS
{
    public class DoanBUS
    {
        public List<PttkDoan> GetAll()
        {
            DoanDAL _context = new DoanDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkDoan>();
            }
        }

        public PttkDoan? GetByID(decimal? ID)
        {
            DoanDAL _context = new DoanDAL();
            try
            {
                return _context.GetByID(ID);
            }
            catch
            {
                return new PttkDoan();
            }
        }
        public PttkDoan? GetByName(string name)
        {
            DoanDAL _context = new DoanDAL();
            try
            {
                return _context.GetByName(name);
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
                DoanDAL _context = new DoanDAL();
                _context.Add(doan);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PttkKhachhang? GetLeaderByID(PttkDoan? id)
        {
            try
            {
                KhachhangBUS khachhangBUS = new KhachhangBUS();
                return khachhangBUS.GetByID(id.Leader);
            }
            catch
            {
                return new PttkKhachhang();
            }
        }
    }
}
