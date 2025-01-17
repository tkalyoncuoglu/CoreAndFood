﻿using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name cannot be empty")] //Neyin üstünde ise ona işlem yapar
        [StringLength(20,ErrorMessage = "Please enter a maximum of 4-20 characters", MinimumLength = 4)]
        public string Name { get; set; }

        public string Description { get; set; } 
        
        public bool Status { get; set; } 

        //Bir Kategori birden fazla Food içerisine yer Alabiliyor!!!
        public List<Product> Products { get; set; }  //Ne tarafta Liste varsa demek ki burası işin -> Ana Kısmı olacak!!!!

       
    }
}
