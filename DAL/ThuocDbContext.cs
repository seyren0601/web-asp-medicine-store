using Microsoft.EntityFrameworkCore;
using Medicine_Store.Entity;

namespace Medicine_Store
{
    public class ThuocDbContext:DbContext
    {
        public ThuocDbContext(DbContextOptions<ThuocDbContext> options) : base(options) { }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
