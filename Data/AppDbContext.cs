using Food.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.Services.CouponAPI.Data
{
    public class AppDbContext :DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public  DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "20OFF",
                DiscountAmount = "20",
                MinAmount = 20
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "25OFF",
                DiscountAmount = "25",
                MinAmount = 25
            });
        }
    }
}
