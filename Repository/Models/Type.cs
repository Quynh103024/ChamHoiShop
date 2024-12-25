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
    public class Type
    {
        [Key]
        public int TypeID { get; set; }

        public string TypeName { get; set; }

        public string Description { get; set; } = "";

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
