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
       // public bool Add(PttkNhanvien dp, PttkKhachhang )
    }
}
