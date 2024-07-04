using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbProduct
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }

    public decimal? PriceNet { get; set; }

    public Guid? UpdateBy { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid? ImageId { get; set; }

    public Guid CategoryId { get; set; }

    public string? Code { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual ICollection<TbInvoiceDetail> TbInvoiceDetails { get; set; } = new List<TbInvoiceDetail>();

    public virtual ICollection<TbOderDetail> TbOderDetails { get; set; } = new List<TbOderDetail>();
}
