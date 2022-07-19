using YelpCampAPI.Models;

namespace YelpCampAPI.Interfaces;

public interface ICampground
{
    IEnumerable<CampgroundModel> Get();
    Task Save(CampgroundModel campground);
    Task Update(int id, CampgroundModel campground);
    Task Delete(int id);
}