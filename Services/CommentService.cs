using YelpCampAPI;
using YelpCampAPI.Models;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Services;

public class CommentService : IComment
{
    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CommentModel> Get()
    {
        throw new NotImplementedException();
    }

    public Task Save(CommentModel comment)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, CommentModel comment)
    {
        throw new NotImplementedException();
    }
}