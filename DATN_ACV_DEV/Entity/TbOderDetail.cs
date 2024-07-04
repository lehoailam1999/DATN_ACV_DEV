using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbOderDetail
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual TbOrder Order { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;

    public virtual ICollection<TbExchangeItem> TbExchangeItems { get; set; } = new List<TbExchangeItem>();

    public virtual ICollection<TbReturnItem> TbReturnItems { get; set; } = new List<TbReturnItem>();
}
