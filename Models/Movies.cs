using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MvcAppFirst.Models
{
    public class Movies
    {
            
            
            public int ID { get; set; }
            [Required]
            public string Title { get; set; }
            [DataType(DataType.DateTime),Required]
            public DateTime ReleaseDate { get; set; }
            [Required]
            public string Genre { get; set; }
            [Required,Range(1,100),DataType(DataType.Currency)]
            public decimal Price { get; set; }
            [Required]
            public string Rating { get; set; }
        

    }
    public class MovieDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
    }
}