﻿using System;
using System.Collections.Generic;

namespace RZA_sly.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int AttractionId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Attraction Attraction { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
