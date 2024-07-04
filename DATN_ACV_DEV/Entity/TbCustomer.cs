using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbCustomer
{
    public Guid Id { get; set; }

    public DateTime? YearOfBirth { get; set; }

    public int? Sex { get; set; }

    public bool IsDelete { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TbAccount> TbAccounts { get; set; } = new List<TbAccount>();
}
