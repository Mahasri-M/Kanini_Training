using System;
using System.Collections.Generic;

namespace DBF_Food.Models;

public partial class Payment
{
    public int PaymentNo { get; set; }

    public int? PayId { get; set; }

    public int? Totalamt { get; set; }

    public virtual PaymentType? Pay { get; set; }
}
