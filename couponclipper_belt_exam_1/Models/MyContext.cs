#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace couponclipper_belt_exam_1.Models;
public class MyContext : DbContext 
{
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<CouponAssociation> CouponAssociations { get; set; }
}
