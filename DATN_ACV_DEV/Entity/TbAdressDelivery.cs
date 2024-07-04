using System;
using System.Collections.Generic;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class TbAdressDelivery
{
    public Guid Id { get; set; }

    public string ProvinceName { get; set; } = null!;

    public int ProviceId { get; set; }

    public string DistrictName { get; set; } = null!;

    public int DistrictId { get; set; }

    public string WardName { get; set; } = null!;

    public bool? Status { get; set; }

    public bool? IsDelete { get; set; }

    public Guid AccountId { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverPhone { get; set; }

    public string? WardCode { get; set; }

    public virtual ICollection<TbAccount> TbAccounts { get; set; } = new List<TbAccount>();
}
