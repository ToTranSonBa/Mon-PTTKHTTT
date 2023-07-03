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

        public bool Update(PttkDatphong pttkDatphong, PttkDoan pttkDoan, int checkdoan)
        {
            try
            {
                DoanBUS doanBUS = new DoanBUS();
                if (checkdoan == 1)
                {
                    pttkDoan.Leader = pttkDatphong.CustomerId;
                    doanBUS.Add(pttkDoan);
                    pttkDoan = doanBUS.GetByName(pttkDoan.Name);
                    pttkDatphong.DoanID = pttkDoan.Id;
                }
                else if (checkdoan == 2)
                {
                    pttkDoan = doanBUS.GetByName(pttkDoan.Name);
                    pttkDatphong.DoanID = pttkDoan.Id;
                }

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
        public bool Add(PttkDatphong pttkDatphong, PttkDoan? pttkDoan, PttkKhachhang pttkKhachhang, int checkdoan)
        {
            try
            {
                KhachhangBUS khachhangBUS = new KhachhangBUS();
                DoanBUS doanBUS = new DoanBUS();
                DatphongDAL datphongDAL = new DatphongDAL();

                var khachhang = khachhangBUS.GetByCCCD(pttkKhachhang.IdentifiedCard);
                if (khachhang == null)
                {
                    khachhangBUS.Add(pttkKhachhang);
                    khachhang = khachhangBUS.GetByCCCD(pttkKhachhang.IdentifiedCard);
                }
                else
                {
                    khachhangBUS.Update(pttkKhachhang);
                }
                if (checkdoan == 1)
                {
                    pttkDoan.Leader = khachhang.Id;
                    doanBUS.Add(pttkDoan);
                    pttkDoan = doanBUS.GetByName(pttkDoan.Name);
                    pttkDatphong.DoanID = pttkDoan.Id;
                }
                else if (checkdoan == 2)
                {
                    pttkDoan = doanBUS.GetByName(pttkDoan.Name);
                    pttkDatphong.DoanID = pttkDoan.Id;
                }
                pttkDatphong.CustomerId = khachhang.Id;
                if(datphongDAL.Add(pttkDatphong))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
