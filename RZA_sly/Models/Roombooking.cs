﻿using System;
using System.Collections.Generic;

namespace RZA_sly.Models;

public partial class Roombooking
{
    public int CustomerId { get; set; }

    public int RoomNumber { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
