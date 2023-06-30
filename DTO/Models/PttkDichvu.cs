using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkDichvu
{
    public decimal Id { get; set; }

    public string? Decsription { get; set; }

    public decimal? Price { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PttkDatphongDichvu> PttkDatphongDichvus { get; set; } = new List<PttkDatphongDichvu>();
}
