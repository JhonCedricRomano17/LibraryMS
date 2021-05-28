using jhoncedricromano.window.Infrastructure.Domain.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhoncedricromano.window.Infrastructure.Domain
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
    : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    bkauthor = "Ken Folett",
                    bkpublisher = "ewan",
                    bktitle = "Fall of Giants",
                    BookID = Guid.NewGuid()

                },
                new Book()
                {
                    bkauthor = "sam frost",
                    bkpublisher = "ewan",
                    bktitle = "The Hidden Maid",
                    BookID = Guid.NewGuid()

                },
                 new Book()
                {
                    bkauthor = "Arthur Blake",
                    bkpublisher = "ewan",
                    bktitle = "Lust Royale",
                    BookID = Guid.NewGuid()

                },

        };
            modelBuilder.Entity<Book>()
            .HasData(books);
        }
    }
}
