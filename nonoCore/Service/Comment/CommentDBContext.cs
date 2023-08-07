using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using nonoCore.Entity;

namespace nonoCore.Service
{
    public class CommentDBContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=nonoDB;Trusted_Connection=True;");
        }
    }
}
