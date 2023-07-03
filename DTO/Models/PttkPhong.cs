using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class PttkPhong
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public decimal Id { get; set; }

    public string? RoomNumber { get; set; }

    public decimal? Price { get; set; }

    public string? RentStatus { get; set; }

    public string? HygieneStatus { get; set; }

    public decimal? Kind { get; set; }

    public virtual PttkLoaiphong? KindNavigation { get; set; }

    public virtual ICollection<PttkPhongDatphong> PttkPhongDatphongs { get; set; } = new List<PttkPhongDatphong>();

    public virtual ICollection<PttkThietbiPhong> PttkThietbiPhongs { get; set; } = new List<PttkThietbiPhong>();
}
