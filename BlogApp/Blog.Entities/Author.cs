using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Author : IdentityUser
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Firstname cannot be greater than 10 characters")]
        public string Firsname { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Firstname cannot be greater than 10 characters")]
        public string Lastname { get; set; }
    }
}