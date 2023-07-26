using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class PaymentType
{
    public int PayId { get; set; }

    public string? PayType { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
