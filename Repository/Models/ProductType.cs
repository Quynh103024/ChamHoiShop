using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Repository.Models
{
    public class ProductType 
    {

        [Key]
        public int ProductTypeID { get; set; }

        public int ProductID { get; set; }

        public int TypeID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("TypeID")]
        public virtual Type Type { get; set; }
    }
}
