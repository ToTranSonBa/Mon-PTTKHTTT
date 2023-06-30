using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkTour
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<PttkTourKhachhang> PttkTourKhachhangs { get; set; } = new List<PttkTourKhachhang>();
}
