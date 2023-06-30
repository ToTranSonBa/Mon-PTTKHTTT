using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PttkTourKhachhang
{
    public decimal Id { get; set; }

    public DateTime? StartTime { get; set; }

    public decimal? ParticipantAmount { get; set; }

    public decimal? TourId { get; set; }

    public decimal? CustomerId { get; set; }

    public virtual PttkKhachhang? Customer { get; set; }

    public virtual PttkTour? Tour { get; set; }
}
