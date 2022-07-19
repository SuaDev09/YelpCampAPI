using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YelpCampAPI.Models;

public class CampgroundModel
{
    public int Id { get; set;}
    public string Name { get; set;}
    public double Price { get; set;}
    public string Img { get; set;}   
}