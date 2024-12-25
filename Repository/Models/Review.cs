using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Repository.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public int ProductID { get; set; }

        public int UserID { get; set; }

        public string Content { get; set; } = "";

        public int? Rating { get; set; }

        public DateTime TimeReview { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

    }
}
