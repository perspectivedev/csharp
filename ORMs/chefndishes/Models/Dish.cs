#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefndishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    [Display(Name = "Name of Dish")]
    public string DishName { get; set; }

    [Range(0,int.MaxValue, ErrorMessage ="Calorie count must be more than 0")]
    [Display(Name = "# of Calories")]
    public int? Calories { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    [Display(Name = "Tastiness")]
    public int? Tastiness { get; set; }
    [Required]
    public int ChefId { get; set; }

    public Chef? Creator { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public DateTime UpdateAt { get; set; } = DateTime.Now;
}