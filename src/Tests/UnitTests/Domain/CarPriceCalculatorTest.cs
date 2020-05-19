using System;
using Domain;
using Xunit;

namespace UnitTests
{
    public class CarPriceCalculatorTest
    {
        [Theory]
        [InlineData(1, 100)]
        [InlineData(2, 200)]
        [InlineData(3, 300)]
        [InlineData(4, 370)]
        [InlineData(5, 440)]
        [InlineData(6, 510)]
        [InlineData(7, 580)]
        [InlineData(8, 650)]
        public void TestSuv(int days, int expected)
        {
            var calculator = new CarPriceCalculator();
            var result = calculator.Calculate(GetSuv(), days);
            
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(1, 150)]
        [InlineData(2, 300)]
        [InlineData(3, 450)]
        [InlineData(4, 600)]
        [InlineData(5, 750)]
        [InlineData(6, 900)]
        [InlineData(7, 1050)]
        [InlineData(8, 1200)]
        public void TestConvertible(int days, int expected)
        {
            var calculator = new CarPriceCalculator();
            var result = calculator.Calculate(GetConvertible(), days);
            
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(1, 100)]
        [InlineData(2, 200)]
        [InlineData(3, 300)]
        [InlineData(4, 400)]
        [InlineData(5, 500)]
        [InlineData(6, 580)]
        [InlineData(7, 660)]
        [InlineData(8, 740)]
        public void TestMinivan(int days, int expected)
        {
            var calculator = new CarPriceCalculator();
            var result = calculator.Calculate(GetMinivan(), days);
            
            Assert.Equal(expected, result);
        }
        
        private PricePolicy GetPremium()
        {
            return new PricePolicy("premium", 150);
        }
        
        private PricePolicy GetBasic()
        {
            return new PricePolicy("basic", 100);
        }
        
        private RentType GetConvertible()
        {
            return new RentType("convertible", 1, GetPremium());
        }
        
        private RentType GetMinivan()
        {
            return new RentType("minivan", 1, GetBasic(), TimeSpan.FromDays(5), 0.2m);
        }
        
        private RentType GetSuv()
        {
            return new RentType("suv", 1, GetBasic(), TimeSpan.FromDays(3), 0.3m);
        }
    }
}
