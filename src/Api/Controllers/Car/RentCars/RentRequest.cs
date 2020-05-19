namespace Api
{
    public class RentRequest
    {
        public string Model { get; private set; }
        public int Days { get; private set; }
        
        private RentRequest()
        {
        }

        public RentRequest(string model, int days)
        {
            Model = model;
            Days = days;
        }
    }
}