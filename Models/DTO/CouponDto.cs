﻿namespace Food.Services.CouponAPI.Models.DTO
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public string DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
