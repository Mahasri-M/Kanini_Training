using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class CustomerDet
{
    public string? Name { get; set; }

    public int MobNum { get; set; }

    public string? City { get; set; }

    public virtual ICollection<OrderDet> OrderDets { get; set; } = new List<OrderDet>();
}
