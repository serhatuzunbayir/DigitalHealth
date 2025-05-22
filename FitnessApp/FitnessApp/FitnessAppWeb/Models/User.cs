using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessAppWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public float WaistCircumference { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}