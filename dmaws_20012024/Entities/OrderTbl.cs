using System;
using System.Collections.Generic;

namespace dmaws_20012024.Entities;

public partial class OrderTbl
{
    public int ItemCode { get; set; }

    public string? ItemName { get; set; }

    public int? ItemQty { get; set; }

    public DateTime? OrderDelivery { get; set; }

    public string? OrderAddress { get; set; }

    public string? PhoneNumber { get; set; }
}
