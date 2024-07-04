using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbPaymentMethod
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CardNumber { get; set; }

    public string? Type { get; set; }

    public bool? InActive { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
