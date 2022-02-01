using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models{

    public class Book{
        [Key]
        public int id {get; set;}
        [Required]
        [MinLength(10,ErrorMessage ="title must be more than 10 letters")]
        public string title {get; set;}
        public string description {get; set;}

    }
}