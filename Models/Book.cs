using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models{

    public class Book{
        [Key]
        public int id {get; set;}
        public string title {get; set;}
        public string description {get; set;}

    }
}