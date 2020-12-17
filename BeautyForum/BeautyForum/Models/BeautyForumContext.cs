using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyForum.Models
{
    public class BeautyForumContext : DbContext
    {
        public BeautyForumContext() : base() { }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StoreContextDb;Trusted_Connection=True;");
        }
    }
}
