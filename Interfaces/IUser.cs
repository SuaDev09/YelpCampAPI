using YelpCampAPI.Models;

namespace YelpCampAPI.Interfaces;

public interface IUser
{
    IEnumerable<UserModel> Get();
    Task Save(UserModel user);
    Task Update(int id, UserModel user);
    Task Delete(int id);
}