using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbOrder
{
    public Guid Id { get; set; }

    public decimal TotalAmount { get; set; }

    public string? Description { get; set; }

    public int? Delivered { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public string NameCustomer { get; set; } = null!;

    public int Status { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? AcountId { get; set; }

    public Guid? PaymentMethodId { get; set; }

    public virtual TbAccount? Acount { get; set; }

    public virtual TbPaymentMethod? PaymentMethod { get; set; }

    public virtual ICollection<TbOderDetail> TbOderDetails { get; set; } = new List<TbOderDetail>();

    public virtual TbVoucher? Voucher { get; set; }
}
