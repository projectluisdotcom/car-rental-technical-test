namespace Api
{
    public class ReturnedCar
    {
        public string LicenseNumber { get; private set; }
        public string Model { get; private set; }
        public int OvertimeDays { get; private set; }
        public int TotalPayed { get; private set; }
        public int ContractedPrice { get; private set; }
        public int Bonus { get; private set; }

        public ReturnedCar(string licenseNumber, string model, int overtimeDays, int totalPayed, int contractedPrice, int bonus)
        {
            LicenseNumber = licenseNumber;
            Model = model;
            OvertimeDays = overtimeDays;
            TotalPayed = totalPayed;
            ContractedPrice = contractedPrice;
            Bonus = bonus;
        }
    }
}