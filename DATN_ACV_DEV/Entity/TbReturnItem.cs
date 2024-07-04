using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbReturnItem
{
    public Guid Id { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public Guid? OrderDetailId { get; set; }

    public virtual TbOderDetail? OrderDetail { get; set; }
}
