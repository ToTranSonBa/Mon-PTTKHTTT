using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;

namespace BUS
{
    public class DatphongBUS
    {
        public List<PttkDatphong> GetAll()
        {
            DatphongDAL dp = new DatphongDAL();
            return dp.GetAll();
        }

        public PttkDatphong? getOneByID(decimal? ID)
        {
            if (ID != null)
            {
                DatphongDAL datPhong = new DatphongDAL();
                return datPhong.GetByID(ID);
            }
            return new PttkDatphong();

        }

        public bool Update(PttkDatphong pttkDatphong)
        {
            try
            {
                DatphongDAL datphongDAL = new DatphongDAL();
                KhachhangBUS khachhangBUS = new KhachhangBUS();
                if(khachhangBUS.Update(pttkDatphong.Customer) && datphongDAL.Update(pttkDatphong))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
