using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models {
    public class BookCtxt : DbContext {
        public BookCtxt(DbContextOptions<BookCtxt> options) : base(options) {}

        public DbSet<Book> books { get; set; }
        public DbSet<Classification> classifications { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb) {
            mb.Entity<Classification>().HasData(
                new Classification {
                    classificationID = 1,
                    classificationName = "fiction"
                },
                new Classification {
                    classificationID = 2,
                    classificationName = "non-fiction"
                }
            );
            mb.Entity<Category>().HasData(
                new Category {
                    categoryID = 1,
                    categoryName = "action"
                },
                new Category {
                    categoryID = 2,
                    categoryName = "biography"
                },
                new Category {
                    categoryID = 3,
                    categoryName = "business"
                },
                new Category {
                    categoryID = 4,
                    categoryName = "christian"
                },
                new Category {
                    categoryID = 5,
                    categoryName = "classic"
                },
                new Category {
                    categoryID = 6,
                    categoryName = "health"
                },
                new Category {
                    categoryID = 7,
                    categoryName = "historical"
                },
                new Category {
                    categoryID = 8,
                    categoryName = "self-help"
                },
                new Category {
                    categoryID = 9,
                    categoryName = "thriller"
                }
            );
        }
    }
}
