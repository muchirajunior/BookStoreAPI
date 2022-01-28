using Microsoft.EntityFrameworkCore;

namespace BookStore.Models {
    public class BookStoreContext : DbContext {
        public BookStoreContext (DbContextOptions<BookStoreContext> options) : base (options) { }

        public DbSet<Book> books {get; set;}
      
    }
}