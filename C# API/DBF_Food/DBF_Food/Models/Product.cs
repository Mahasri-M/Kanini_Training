using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class Product
{
    public int PId { get; set; }

    public string? CId { get; set; }

    public int? TypeId { get; set; }

    public string? PName { get; set; }

    public int? Cost { get; set; }

    public virtual Category? CIdNavigation { get; set; }

    public virtual ICollection<OrderDet> OrderDets { get; set; } = new List<OrderDet>();

    public virtual FoodType? Type { get; set; }
}
