namespace Api
{
    public class AvailableCar
    {
        public string LicenseNumber { get; private set; }
        public string Model { get; private set; }
        public string PayPolicy { get; private set; }

        public AvailableCar(string licenseNumber, string model, string payPolicy)
        {
            LicenseNumber = licenseNumber;
            Model = model;
            PayPolicy = payPolicy;
        }
    }
}