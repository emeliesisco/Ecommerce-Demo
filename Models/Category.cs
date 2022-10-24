using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models
{
    public class Category
    {
        [Key]
        public int MyId { get; set; }
        [Required]
        public string ?Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="the display order is invalid")]
        public int DisplayOrder{ get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
  