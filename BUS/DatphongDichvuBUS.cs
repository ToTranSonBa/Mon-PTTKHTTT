using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;

namespace BUS
{
    public class DatphongDichvuBUS
    {
        public List<PttkDatphongDichvu> GetAll()
        {
            DatphongDichvuDAL datphongDichvuDAL = new DatphongDichvuDAL();
            try
            {
                return datphongDichvuDAL.GetAll();

            }
            catch
            {
                return new List<PttkDatphongDichvu>();
            }
        }

        public List<PttkDatphongDichvu> GetAllbyOrderID(decimal? ID)
        {
            DatphongDichvuDAL datphongDichvu = new DatphongDichvuDAL();
            try
            {
                return datphongDichvu.GetAllByOrderID(ID);
            }
            catch
            {
                return new List<PttkDatphongDichvu>();
            }
        }

        public PttkDatphongDichvu GetOnebyID(decimal? ID)
        {
            DatphongDichvuDAL datphongDichvu = new DatphongDichvuDAL();
            try
            {
                return datphongDichvu.GetByID(ID);
            }
            catch
            {
                return new PttkDatphongDichvu();
            }
            
        }

        public bool AddListDatphongDichvu(List<PttkDichvu> dichvus, decimal? ID)
        {
            try
            {
                DatphongDichvuDAL datphongDichvu;
                foreach(var item in dichvus)
                {
                    try
                    {
                        PttkDatphongDichvu insertDpDv = new PttkDatphongDichvu();
                        insertDpDv.OrderId = ID;
                        insertDpDv.ServiceId = item.Id;
                        datphongDichvu = new DatphongDichvuDAL();
                        datphongDichvu.Add(insertDpDv);
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
