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
    }
}
