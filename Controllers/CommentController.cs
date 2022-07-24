using Microsoft.AspNetCore.Mvc;
using YelpCampAPI.Models;
using YelpCampAPI.Services;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Controllers;

[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    IComment commentService;
    YelpCampContext dbcontext;

    public CommentController(IComment service, YelpCampContext db)
    {
        commentService = service;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(commentService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] CommentModel comment)
    {
        commentService.Save(comment);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CommentModel comment)
    {
        commentService.Update(id, comment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        commentService.Delete(id);
        return Ok();
    }
}