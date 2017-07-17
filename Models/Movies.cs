using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace MvcAppFirst.Models
{
    public class Movies
    {
       
            public int ID { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
       
        

    }
    public class MovieDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
    }
}