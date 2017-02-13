using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CatProject.Models
{
    public class Cat
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Names")]
        [Required]
        [StringLength(10)]
        public string names { get; set; }

        [Display(Name = "Ages")]
        [Required]
        [Range(1, 20)]
        public int ages { get; set; }

        [Display(Name = "Color")]
        public Color color { get; set; }
    }

    public enum Color
    {
        White,
        Gray,
        Black
    }

    public class CatDbContext : DbContext
    {
        public DbSet<Cat> cats { get; set; }
    }
}