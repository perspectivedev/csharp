#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefndishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string DishName { get; set; }

    [Range(0,int.MaxValue, ErrorMessage ="Calorie count must be more than 0")]
    [Display(Name = "# of Calories")]
    public int? Calories { get; set; }

    [Required]
    public string ChefName { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int? Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public DateTime UpdateAt { get; set; } = DateTime.Now;
}