#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace couponclipper_belt_exam_1.Models;

public class Coupon
{
    [Key]
    public int CouponId { get; set; }
    [Required]
    [Display(Name = "Coupon Code")]
    public int CouponCode { get; set; }
    [Required]
    [Display(Name = "Website applicable on")]
    public string Website { get; set; }
    [Required]
    [Display(Name = "Description")]
    [MinLength(10, ErrorMessage="Description must be at least ten characters long.")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required]
    public int UserId { get; set; }
    public List<CouponAssociation> CouponTracker { get; set; } = new List<CouponAssociation>();
}