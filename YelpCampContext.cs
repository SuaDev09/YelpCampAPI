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
            CampgroundModel.ToTable("Campgrounds");
            CampgroundModel.HasKey(p => p.Id);
            CampgroundModel.Property(p => p.Name).IsRequired().HasMaxLength(150);
            CampgroundModel.Property(p => p.Description).IsRequired(false);
            CampgroundModel.Property(p => p.Price);
            CampgroundModel.Property(p => p.Img).IsRequired();
            CampgroundModel.HasOne<UserModel>(p => p.User).WithMany(u => u.Campgrounds).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<UserModel>(UserModel => 
        {
            UserModel.ToTable("Users");
            UserModel.HasKey(p => p.Id);
            UserModel.Property(p => p.Name).IsRequired();
            UserModel.Property(p => p.UserName).IsRequired();
            UserModel.Property(p => p.Password).IsRequired();
        });

        modelBuilder.Entity<CommentModel>(CommentModel =>
        {
            CommentModel.ToTable("Comments");
            CommentModel.HasKey(p => p.Id);
            CommentModel.HasOne<UserModel>(u => u.userModel).WithMany(p => p.Comments).HasForeignKey(u => u.IdUser).OnDelete(DeleteBehavior.Cascade);
            CommentModel.HasOne<CampgroundModel>( c => c.campgroundModel).WithMany(p => p.Comments).HasForeignKey(c => c.IdCampgorund).OnDelete(DeleteBehavior.Cascade);
        });
    }
}
