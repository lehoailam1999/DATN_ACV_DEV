using DATN_ACV_DEV.Entity_ALB;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATN_ACV_DEV.Entity
{
    public class BillStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TbOrder> tbOrder { get; set; }
    }
}
