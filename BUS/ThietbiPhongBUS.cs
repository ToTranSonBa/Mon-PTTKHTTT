using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL;
namespace BUS
{
    public class ThietbiPhongBUS
    {
        public List<PttkThietbiPhong> GetAll()
        {
            ThietbiPhongDAL _context = new ThietbiPhongDAL();
            try
            {
                return _context.GetAll();
            }
            catch
            {
                return new List<PttkThietbiPhong>();
            }
        }

        public PttkThietbiPhong? GetByID(decimal ID)
        {
            ThietbiPhongDAL _context = new ThietbiPhongDAL();
            try
            {
                return _context.GetByID(ID);
            }
            catch
            {
                return new PttkThietbiPhong();
            }
        }

        public bool Add(PttkThietbiPhong thietBiPhong)
        {
            try
            {
                ThietbiPhongDAL thietbiphong_dal = new ThietbiPhongDAL();
                thietbiphong_dal.Add(thietBiPhong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(PttkThietbiPhong thietBiPhong)
        {
            try
            {
                ThietbiPhongDAL thietbiphong_dal=new ThietbiPhongDAL();
                thietbiphong_dal.Remove(thietBiPhong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PttkThietbiPhong thietBiPhong)
        {
            try
            {
                ThietbiPhongDAL thietbiphong_dal = new ThietbiPhongDAL();
                thietbiphong_dal.Update(thietBiPhong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public decimal? GetAmountofEquipment(decimal? ID)
        {
            try
            {
                ThietbiPhongDAL thietbiphong_dal = new ThietbiPhongDAL();
                List<PttkThietbiPhong> thietbiphong_list=new List<PttkThietbiPhong>();
                thietbiphong_list = thietbiphong_dal.GetAll();
                List<PttkThietbiPhong> t = new List<PttkThietbiPhong>();

                foreach(var tb in thietbiphong_list)
                {
                    if (tb != null)
                    {
                        if(tb.EquipmentId == ID)
                        {
                            t.Add(tb);
                        }
                    }
                }

                decimal? count = 0;
                foreach (var tb in t)
                {
                    if (tb != null)
                    {
                        count += tb.Amount;
                    }
                }
                return count;
            }
            catch
            {
                return 0;
            }
        }
    }
}
