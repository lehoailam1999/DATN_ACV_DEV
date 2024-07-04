using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbInvoice
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public bool? IsDelete { get; set; }

    public DateTime InputDate { get; set; }

    public Guid? UpdateBy { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<TbInvoiceDetail> TbInvoiceDetails { get; set; } = new List<TbInvoiceDetail>();
}
