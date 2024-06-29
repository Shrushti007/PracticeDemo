using System.ComponentModel.DataAnnotations;

namespace PracticeDemo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
