using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkDatphong
{
    public decimal Id { get; set; }

    public DateTime? CreatedDay { get; set; }

    public decimal? EmployeeId { get; set; }

    public decimal? CustomerId { get; set; }

    public virtual PttkKhachhang? Customer { get; set; }

    public virtual PttkNhanvien? Employee { get; set; }

    public DateTime? LeavingDay { get; set; }

    public DateTime? ArrivalDay { get; set; }

    public DateTime? NgayThanhToan { get; set; }

    public virtual ICollection<PttkDatphongDichvu> PttkDatphongDichvus { get; set; } = new List<PttkDatphongDichvu>();

    public virtual ICollection<PttkPhongDatphong> PttkPhongDatphongs { get; set; } = new List<PttkPhongDatphong>();
}
