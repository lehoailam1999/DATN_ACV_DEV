using DATN_ACV_DEV.Entity_ALB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATN_ACV_DEV.Entity
{
    public class ConfirmEmail
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime ExpiredTime { get; set; }
        public string CodeActive { get; set; }
        public bool IsConfirm { get; set; } = false;
        [ForeignKey("AccountId")]
        public Guid AccountId { get; set; }
        public TbAccount tbAccount { get; set; }
    }
}
