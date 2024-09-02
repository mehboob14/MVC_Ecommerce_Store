using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Orders")]
        [Range(0, 50, ErrorMessage = "Custom Error Message will define here!")]
        public int DisplayOrders { get; set; }
    }
}
