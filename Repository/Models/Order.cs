﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Repository.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime TimeOrder { get; set; }

        public string Note { get; set; } = "";

        public bool OrderStatus { get; set; } = true;

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
