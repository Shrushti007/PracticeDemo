using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeDemo.Models
{
    public class Order
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Price { get; set; }

        [ForeignKey("userFK")]
        public User user { get; set; }
    }
    
}
