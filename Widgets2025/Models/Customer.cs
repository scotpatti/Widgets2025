using System;
using System.Collections.Generic;

namespace Widgets2025.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? CreditRating { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
