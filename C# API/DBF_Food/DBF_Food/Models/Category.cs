using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class Category
{
    public string CId { get; set; } = null!;

    public string? CType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
