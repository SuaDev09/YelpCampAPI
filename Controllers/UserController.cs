using Microsoft.AspNetCore.Mvc;
using YelpCampAPI.Models;
using YelpCampAPI.Services;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Controllers;

[Route("api/[controller]")]

public class UserController : ControllerBase
{
    IUser userService;
    YelpCampContext dbcontext;
    public UserController(IUser service, YelpCampContext db)
    {
        userService = service;
        dbcontext = db;
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(userService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserModel user)
    {
        userService.Save(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UserModel user)
    {
        userService.Update(id, user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        userService.Delete(id);
        return Ok();
    }
}