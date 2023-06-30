using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkDoan
{
    public decimal Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Name { get; set; }

    public decimal? Leader { get; set; }

    public virtual PttkKhachhang? LeaderNavigation { get; set; }

    public virtual ICollection<PttkKhachhangDoan> PttkKhachhangDoans { get; set; } = new List<PttkKhachhangDoan>();
}
