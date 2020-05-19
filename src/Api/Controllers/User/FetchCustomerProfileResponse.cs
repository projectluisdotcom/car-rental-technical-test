namespace Api.User
{
    public class FetchCustomerProfileResponse
    {
        public string UserName { get; private set; }
        public int CarRentsCount { get; private set; }

        private FetchCustomerProfileResponse()
        {
        }

        public FetchCustomerProfileResponse(string userName, int carRentsCount)
        {
            UserName = userName;
            CarRentsCount = carRentsCount;
        }
    }
}