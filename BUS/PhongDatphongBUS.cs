using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;

namespace BUS
{
    public class PhongDatphongBUS
    {
        public List<PttkPhongDatphong> getAll()
        {
            PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
            return phongDatphong.GetAll();
        }

        public PttkPhongDatphong getOneByRoomID(decimal? ID)
        {
            PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
            return phongDatphong.getOneByRoomID(ID);
        }
        public List<PttkPhongDatphong> GetByOrderID(decimal? ID)
        {
            PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
            return phongDatphong.GetByOrderID(ID);
        }
        public bool CheckPhongDatphong(decimal phong, decimal datphong)
        {
            PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
            if (phongDatphong.GetByPhongIDAndDatphongID(phong, datphong) != null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddByPhongIDAndDatphongID(PttkPhong phong, decimal datphong)
        {
            try
            {
                PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
                var check = phongDatphong.GetByPhongIDAndDatphongID(phong.Id, datphong);
                if (check == null)
                {
                    
                    PhongDAL phongDAL = new PhongDAL();
                    phong.RentStatus = "Occupied";
                    if (phongDAL.Update(phong) && phongDatphong.Add(new PttkPhongDatphong { RoomId = phong.Id, OrderId = datphong }))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
        public bool RemoveByPhongIDAndDatphongID(PttkPhong phong, decimal datphong)
        {
            try
            {
                PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
                var check = phongDatphong.GetByPhongIDAndDatphongID(phong.Id, datphong);
                if (check != null)
                {
                    
                    PhongDAL phongDAL   = new PhongDAL();
                    phong.RentStatus = "Vacant";
                    if (phongDAL.Update(phong) && phongDatphong.Remove(check))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public List<PttkPhong> GetAllByOrderID(decimal orderID)
        {
            try
            {
                PhongBUS phongBUS = new PhongBUS();
                PhongDatphongBUS phongDatphongBUS = new PhongDatphongBUS();
                var datphongphongByID = phongDatphongBUS.GetByOrderID(orderID).Select(t => t.RoomId);
                var dsphong = phongBUS.GetAll().Where(t => datphongphongByID.Contains(t.Id)).ToList();
                return dsphong;
            }
            catch
            {
                return new List<PttkPhong>();
            }
        }
    }
}
