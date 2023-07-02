using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkDatphongDichvu
{
    public decimal Id { get; set; }

    public decimal? ServiceId { get; set; }

    public decimal? OrderId { get; set; }

    public decimal? TotalPrice { get; set; }
    public decimal? Quantity { get; set; }

    public virtual PttkDatphong? Order { get; set; }

    public virtual PttkDichvu? Service { get; set; }
}
