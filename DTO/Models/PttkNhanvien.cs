using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkNhanvien
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Sex { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? NumberPhone { get; set; }

    public DateTime? HireDay { get; set; }

    public string? IdentifiedCard { get; set; }

    public string? Kind { get; set; }

    public DateTime? FireDay { get; set; }

    public virtual ICollection<PttkDatphong> PttkDatphongs { get; set; } = new List<PttkDatphong>();

    public virtual ICollection<PttkTaikhoan> PttkTaikhoans { get; set; } = new List<PttkTaikhoan>();
}
