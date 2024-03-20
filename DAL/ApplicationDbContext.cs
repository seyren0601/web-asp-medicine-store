using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Medicine_Store.DAL.Entities;

namespace Medicine_Store.DAL
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        DbSet<Thuoc> Thuoc { get; set; }
        DbSet<Don_hang> Don_hang { get; set; }
        DbSet<Chi_tiet_don_hang> Chi_tiet_don_hang { get; set; }
    }
}
