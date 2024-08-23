using DATN_ACV_DEV.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

/*    public Guid? UpdateBy { get; set; }
*/
    public DateTime? UpdateDate { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? AddressDeliveryId { get; set; }

    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    public Role role { get; set; }
    public virtual TbAdressDelivery? AddressDelivery { get; set; }

    public virtual TbCustomer? Customer { get; set; }
    public IEnumerable<RefreshToken>? refreshToken { get; set; }
    public IEnumerable<ConfirmEmail>? confirmEmail { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
