﻿using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(1)]
        public string Role { get; set; }
    }
}
