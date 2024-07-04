using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbInvoiceDetail
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public decimal Price { get; set; }

    public string? Unit { get; set; }

    public Guid? SupplierId { get; set; }

    public Guid? IdInvoice { get; set; }

    public virtual TbInvoice? IdInvoiceNavigation { get; set; }

    public virtual TbProduct Product { get; set; } = null!;
}
