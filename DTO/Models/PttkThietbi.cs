using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkThietbi
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PttkThietbiPhong> PttkThietbiPhongs { get; set; } = new List<PttkThietbiPhong>();
}
