using DATN_ACV_DEV.Entity_ALB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATN_ACV_DEV.Entity
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<TbAccount> tbAccounts { get; set; }
    }
}
