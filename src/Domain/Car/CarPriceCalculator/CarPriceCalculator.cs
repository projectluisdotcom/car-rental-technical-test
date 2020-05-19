using System;

namespace Domain
{
    public class CarPriceCalculator : ICarPriceCalculator
    {
        public int Calculate(RentType rent, int days)
        {
            var daysWithDiscount = days - rent.DiscountAfter.Days;
            var discount = (int) (Math.Max(daysWithDiscount, 0) * rent.PricePolicy.Price * (1 - rent.Discount));
            var noDiscount = Math.Min(rent.DiscountAfter.Days, days) * rent.PricePolicy.Price;
            return discount + noDiscount;
        }
    }
}