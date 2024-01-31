using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public partial class BackendContext : DbContext
    {
        public BackendContext()
        {
        }
        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BENAME\\SQLEXPRESS;Initial Catalog=backend;Integrated Security=True; TrustServerCertificate=True;");
            }
        }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
            .HasMany(n => n.NoteCategories) 
            .WithOne(nc => nc.Note) 
            .HasForeignKey(nc => nc.NoteId); 

            modelBuilder.Entity<Category>()
                .HasMany(c => c.NoteCategories) 
                .WithOne(nc => nc.Category) 
                .HasForeignKey(nc => nc.CategoryId); 
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
