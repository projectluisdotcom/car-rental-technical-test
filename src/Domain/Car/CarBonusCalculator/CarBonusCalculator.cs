namespace Domain
{
    public class CarBonusCalculator : ICarBonusCalculator
    {
        public int Calculate(RentType model)
        {
            return model.BonusOnRent;
        }
    }
}