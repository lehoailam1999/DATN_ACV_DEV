using DATN_ACV_DEV.Entity_ALB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATN_ACV_DEV.Entity
{
    public class RefreshToken
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        public string Token { get; set; }
        public DateTime ExpiresTime { get; set; }
        [ForeignKey("AccountId")]
        public Guid AccountId { get; set; }
        public TbAccount tbAccount { get; set; }
    }
}
