using System;
using System.Collections.Generic;

namespace Widgets2025.Models;

public partial class Sale
{
    public int SaleNumber { get; set; }

    public int? CustId { get; set; }

    public int? WidgetId { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual Widget? Widget { get; set; }
}
