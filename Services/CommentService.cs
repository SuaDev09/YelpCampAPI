using YelpCampAPI;
using YelpCampAPI.Models;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Services;

public class CommentService : IComment
{
    YelpCampContext context;

    public CommentService(YelpCampContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<CommentModel> Get()
    {
        return context.Comments;
    }

    public async Task Save(CommentModel comment)
    {
        context.Add(comment);
        await context.SaveChangesAsync();
    }

    public async Task Update(int id, CommentModel comment)
    {
        var commentActual = context.Comments.Find(id);

        if(commentActual != null)
        {
            commentActual.Comment = comment.Comment;
            await context.SaveChangesAsync();
        }
    }
    
    public async Task Delete(int id)
    {
        var commentActual = context.Comments.Find(id);

        if(commentActual != null)
        {
            context.Remove(commentActual);
            await context.SaveChangesAsync();
        }
    }
}