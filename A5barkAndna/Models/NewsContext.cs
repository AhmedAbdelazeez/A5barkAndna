using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace A5barkAndna.Models
{
    public class NewsContext :DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
    {
    }


        public DbSet<Category> categories { get; set; }
        public DbSet<News> News { get; set; }
        
        public DbSet<Teammember> teammembers { get; set; }

       public DbSet<Contactus> contacts { get; set; }

    }

}
