using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YelpCampAPI.Models;

public class CommentModel 
{
    public int Id { get; set;}
    public int IdUser { get; set;}
    public string Comment { get; set;}
    public CampgroundModel campgroundModel { get; set;}
    public UserModel userModel { get; set;}

}