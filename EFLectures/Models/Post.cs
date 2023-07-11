#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// namespace EFLectures.Models;
public class Post
{
    [Key]
    public int PostId { get; set; }
    [Required]
    [MinLength(3, ErrorMessage ="Must be 3 characters in length.")]
    [MaxLength(45, ErrorMessage ="Must be 3 characters in length.")]
    public string Topic { get; set; } 
    [Required]
    [MinLength(3, ErrorMessage ="Must be 3 characters in length.")]
    public string Body { get; set; }
    [Display(Name="Image URL")]
    public string ImgUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
