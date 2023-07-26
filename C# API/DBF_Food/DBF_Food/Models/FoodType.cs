using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class FoodType
{
    public int TypeId { get; set; }

    public string? Specification { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
