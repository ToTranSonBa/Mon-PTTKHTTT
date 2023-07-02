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
                List<PttkDatphongDichvu> _listcheckDpDv = new List<PttkDatphongDichvu>();
                DatphongDichvuBUS datphongDichvuBUS = new DatphongDichvuBUS();

                _listcheckDpDv = datphongDichvuBUS.GetAllbyOrderID(ID);

                foreach(var dichvu in dichvus)
                {
                    foreach(var datphongdichvu in _listcheckDpDv)
                    {
                        if(dichvu.Id == datphongdichvu.ServiceId)
                        {
                            if (datphongdichvu.Quantity == null)
                            {
                                datphongdichvu.Quantity = 1;
                            }
                            else
                            {
                                datphongdichvu.Quantity += 1;
                            }
                            datphongdichvu.TotalPrice = datphongdichvu.Quantity * dichvu.Price;
                            datphongDichvuBUS.Update(datphongdichvu);
                        }
                        else
                        {
                            datphongdichvu.Quantity = 1;
                            datphongDichvuBUS.Add(datphongdichvu);
                        }    
                    }    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // add one
        public bool Add(PttkDatphongDichvu pttkDatphongDichvu)
        {
            DatphongDichvuDAL datphongDichvu = new DatphongDichvuDAL();
            try
            {
                datphongDichvu.Add(pttkDatphongDichvu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // add one
        public bool Update(PttkDatphongDichvu pttkDatphongDichvu)
        {
            DatphongDichvuDAL datphongDichvu = new DatphongDichvuDAL();
            try
            {
                datphongDichvu.Update(pttkDatphongDichvu);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
