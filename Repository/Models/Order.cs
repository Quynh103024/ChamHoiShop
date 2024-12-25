using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminAuthorization.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime TimeOrder { get; set; }

        public string Note { get; set; } = "";

        public bool OrderStatus { get; set; } = true;

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
