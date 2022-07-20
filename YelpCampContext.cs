using Microsoft.EntityFrameworkCore;
using YelpCampAPI.Models;

namespace YelpCampAPI;

public class YelpCampContext: DbContext
{
    public DbSet<CampgroundModel> Campgrounds { get; set;}
    public DbSet<UserModel> Users { get; set;}

    public DbSet<CommentModel> Comments { get; set;}

    public YelpCampContext(DbContextOptions<YelpCampContext> options) :base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CampgroundModel>(CampgroundModel =>
        {
            CampgroundModel.ToTable("Campground");
            CampgroundModel.HasKey(p => p.Id);
            CampgroundModel.Property(p => p.Name).IsRequired().HasMaxLength(150);
            CampgroundModel.Property(p => p.Description).IsRequired(false);
            CampgroundModel.Property(p => p.Price);
            CampgroundModel.Property(p => p.Img).IsRequired();
            CampgroundModel.HasOne<UserModel>(p => p.User).WithMany(u => u.Campgrounds).HasForeignKey(p => p.IdUser);
        });
    }


}