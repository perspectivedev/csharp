#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace dojosurvey_with_validation.Models;
public class Survey
{
    [Required(ErrorMessage ="Name is required!")]
    [MinLength(2, ErrorMessage ="Name must be at least 2 characters in length.")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Select a Location.")]
    public string Location {get; set;}
    [Required(ErrorMessage ="Select a Favorite Language.")]
    public string Language {get; set;}
    // Comment is now optional with the appendage of the ? to type declaration
    // [Required(ErrorMessage ="Comment is optional.")]
    [MinLength(20, ErrorMessage ="Comment must be at least 20 characters in lenght")]
    public string? Comment {get; set;}
}