namespace Api
{
    public class RentContract
    {
        public string CarLicense { get; private set; } 
        public string Model { get; private set; } 
        public int Price { get; private set; }
        public int Bonus { get; private set; }

        public RentContract(string carLicense, string model, int price, int bonus)
        {
            CarLicense = carLicense;
            Model = model;
            Price = price;
            Bonus = bonus;
        }
    }
}