using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Medicine_Store.DAL.Entities;

namespace Medicine_Store.DAL
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Thuoc> Thuoc { get; set; }
        public DbSet<Don_hang> Don_hang { get; set; }
        public DbSet<Chi_tiet_don_hang> Chi_tiet_don_hang { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_details> Cart_Details { get; set; }
    }
}
