using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkTaikhoan
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public decimal? EmployeeId { get; set; }

    public virtual PttkNhanvien? Employee { get; set; }
}
