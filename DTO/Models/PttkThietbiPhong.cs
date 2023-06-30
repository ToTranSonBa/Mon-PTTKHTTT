using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkThietbiPhong
{
    public decimal Id { get; set; }

    public decimal? EquipmentId { get; set; }

    public decimal? RoomId { get; set; }

    public string? Tinhtrang { get; set; }

    public decimal? Amount { get; set; }

    public virtual PttkThietbi? Equipment { get; set; }

    public virtual PttkPhong? Room { get; set; }
}
