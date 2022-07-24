using YelpCampAPI.Models;

namespace YelpCampAPI.Interfaces;

public interface IComment
{
    IEnumerable<CommentModel> Get();
    Task Save(CommentModel comment);
    Task Update(int id, CommentModel comment);
    Task Delete(int id);
}