using Microsoft.AspNetCore.Mvc;
using YelpCampAPI.Models;
using YelpCampAPI.Services;
using YelpCampAPI.Interfaces;

namespace YelpCampAPI.Controllers;

[Route("api/[controller]")]
public class CampgroundController: ControllerBase
{
    ICampground campgroundService;

    public CampgroundController(ICampground service)
    {   
        campgroundService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return OK(campgroundService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] CampgroundModel campground)
    {
        campgroundService.Save(campground);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CampgroundModel campground)
    {
        campgroundService.Update(id, campground);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        campgroundService.Delete(id);
        return Ok();
    }
}