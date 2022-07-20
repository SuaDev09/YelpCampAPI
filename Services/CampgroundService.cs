using YelpCampAPI;
using YelpCampAPI.Models;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Services;

public class CampgroundService : ICampground
{
    YelpCampContext context;

    public CampgroundService(YelpCampContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<CampgroundModel> Get()
    {
        return context.Campgrounds;
    }
    
    public async Task Save(CampgroundModel campground)
    {
        context.Add(campground);
        await context.SaveChangesAsync();
    }

    public async Task Update(int id, CampgroundModel campground)
    {
        var campgroundActual = context.Campgrounds.Find(id);

        if(campgroundActual != null)
        {
            campgroundActual.Name = campground.Name;
            campgroundActual.Img = campground.Img;
            campgroundActual.Price = campground.Price;
            campgroundActual.Description = campground.Description;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var campgroundActual = context.Campgrounds.Find(id);

        if(campgroundActual != null)
        {
            context.Remove(campgroundActual);
            await context.SaveChangesAsync();
        }
    }
}