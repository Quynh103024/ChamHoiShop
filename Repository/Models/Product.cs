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
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}
