using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class OrderDet
{
    public int OrderId { get; set; }

    public string? Name { get; set; }

    public int? MobNum { get; set; }

    public int? PId { get; set; }

    public int? Quantity { get; set; }

    public int? Amt { get; set; }

    public virtual CustomerDet? MobNumNavigation { get; set; }

    public virtual Product? PIdNavigation { get; set; }
}
