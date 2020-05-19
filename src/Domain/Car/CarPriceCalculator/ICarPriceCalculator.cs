namespace Domain
{
    public interface ICarPriceCalculator
    {
        int Calculate(RentType rent, int days);
    }
}