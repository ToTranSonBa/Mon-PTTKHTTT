using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkLoaiphong
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<PttkPhong> PttkPhongs { get; set; } = new List<PttkPhong>();
}
