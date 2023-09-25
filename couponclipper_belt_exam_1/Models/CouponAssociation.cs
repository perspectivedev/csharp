#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace couponclipper_belt_exam_1.Models;

public class CouponAssociation
{
    [Key]
    public int CouponAssociationId { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int CouponId { get; set; }
    public Coupon? Coupon { get; set; }//Come back and fix Coupons to Coupon
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}