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
        public bool AddPhanPhong(List<PttkPhong> pttkPhongs, PttkDatphong pttkDatphong)
        {
            try
            {
                PhongDatphongDAL phongDatphong = new PhongDatphongDAL();
                foreach (var phong in pttkPhongs)
                {
                    if (phong != null)
                    {
                        if (CheckPhongDatphong(phong.Id, pttkDatphong.Id))
                        {
                            continue;
                        }
                        else
                        {
                            phongDatphong.Add(new PttkPhongDatphong { OrderId = pttkDatphong.Id, RoomId = phong.Id });
                        }
                    }
                }

                var dsPhongdatphong = phongDatphong.GetByOrderID(pttkDatphong.Id);
                var dsPhongId = pttkPhongs.Select(r => r.Id).ToList();
                var deletePhongDatPhong = dsPhongdatphong.Where(i => dsPhongId.Any(a => a != i.RoomId));
                foreach (var d in deletePhongDatPhong)
                {
                    if (d != null)
                    {
                        phongDatphong.Remove(d);
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
