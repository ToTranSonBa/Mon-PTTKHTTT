using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkPhongDatphong
{
    public decimal Id { get; set; }

    public decimal? RoomId { get; set; }

    public decimal? OrderId { get; set; }

    public virtual PttkDatphong? Order { get; set; }

    public virtual PttkPhong? Room { get; set; }
}
