
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YelpCampAPI.Models;

public class UserModel
{
    public int Id { get; set;}
    public string? UserName { get; set;}
    public string? Name { get; set;}
    [JsonIgnore]
    public virtual ICollection<CampgroundModel>? Campgrounds { get; set;}
    [JsonIgnore]
    public virtual ICollection<CommentModel>? Comments { get; set;}
    [JsonIgnore]
    public string? Password { get; set;}

}