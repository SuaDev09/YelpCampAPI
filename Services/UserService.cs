using YelpCampAPI;
using YelpCampAPI.Models;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Services;

public class UserService : IUser
{
    YelpCampContext context;

    public UserService(YelpCampContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<UserModel> Get()
    {
        return context.Users;
    }

    public async Task Save(UserModel user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task Update(int id, UserModel user)
    {
        var userActual = context.Users.Find(id);

        if(userActual != null)
        {
            userActual.Name = user.Name;
            userActual.Password = user.Password;
            userActual.UserName = user.UserName;
            await context.SaveChangesAsync();
        }
    }
    
    public async Task Delete(int id)
    {
        var userActual = context.Users.Find(id);

        if(userActual != null)
        {
            context.Remove(userActual);
            await context.SaveChangesAsync();
        }
    }
}