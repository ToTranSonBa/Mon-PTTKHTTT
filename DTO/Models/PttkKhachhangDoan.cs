using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkKhachhangDoan
{
    public decimal Id { get; set; }

    public decimal? DoanId { get; set; }

    public decimal? CustomerId { get; set; }

    public virtual PttkKhachhang? Customer { get; set; }

    public virtual PttkDoan? Doan { get; set; }
}
