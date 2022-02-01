using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class User{
        
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
    }
    
}