using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkKhachhang
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public string? Sex { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? NumberPhone { get; set; }

    public string? IdentifiedCard { get; set; }

    public decimal? PttkDoanId { get; set; }

    public virtual ICollection<PttkDatphong> PttkDatphongs { get; set; } = new List<PttkDatphong>();

    public virtual ICollection<PttkDoan> PttkDoans { get; set; } = new List<PttkDoan>();

    public virtual ICollection<PttkKhachhangDoan> PttkKhachhangDoans { get; set; } = new List<PttkKhachhangDoan>();

    public virtual ICollection<PttkTourKhachhang> PttkTourKhachhangs { get; set; } = new List<PttkTourKhachhang>();
}
