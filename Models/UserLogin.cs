using System.ComponentModel.DataAnnotations;

namespace  BookStore.Models
{
    public class UserLogin{
        [Required]
        public string  username { get; set; }
        [Required]
        public string password { get; set; }
        
    }
}