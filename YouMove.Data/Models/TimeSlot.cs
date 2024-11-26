﻿using System;
using System.Collections.Generic;

namespace YouMove.Data.Models;

public partial class TimeSlot
{
    public int TimeSlotId { get; set; }

    public int StartTime { get; set; }

    public int EndTime { get; set; }

    public string PartOfDay { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
