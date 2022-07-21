using YelpCampAPI;
using YelpCampAPI.Models;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Services;

public class UserService : IUser
{
    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserModel> Get()
    {
        throw new NotImplementedException();
    }

    public Task Save(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, UserModel user)
    {
        throw new NotImplementedException();
    }
}