
﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Models;
using DAL;

namespace BUS
{
    public class PhongBUS
    {

        public List<PttkPhong> GetAll()
        {
            PhongDAL phongDAL = new PhongDAL();
            return phongDAL.GetAll();
        }
    }
}
