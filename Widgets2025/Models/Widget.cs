using System;
using System.Collections.Generic;

namespace Widgets2025.Models;

public partial class Widget
{
    public int WidgetId { get; set; }

    public string? Name { get; set; }

    public decimal? CurrentPrice { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
