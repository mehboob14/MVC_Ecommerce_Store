using System.ComponentModel.DataAnnotations;

namespace day_01.Models
{
    public class Category
    {
        [Key]
       public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrders { get; set; }
    }
}
