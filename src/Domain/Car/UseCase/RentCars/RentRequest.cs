namespace Domain
{
    public class RentRequest
    {
        public string Model { get; private set; }
        public int Days { get; private set; }

        public RentRequest(string model, int days)
        {
            Model = model;
            Days = days;
        }
    }
}