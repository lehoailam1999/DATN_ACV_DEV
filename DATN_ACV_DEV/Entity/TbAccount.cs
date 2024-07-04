using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbAccount
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public string IsDelete { get; set; } = null!;

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? AddressDeliveryId { get; set; }

    public virtual TbAdressDelivery? AddressDelivery { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
