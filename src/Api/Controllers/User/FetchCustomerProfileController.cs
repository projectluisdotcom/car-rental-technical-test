using System.Net;
using System.Threading.Tasks;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Api.User
{
    [ApiController]
    public class FetchCustomerProfileController
    {
        private readonly IFetchCustomerProfile _fetchCustomerProfile;

        public FetchCustomerProfileController(IFetchCustomerProfile fetchCustomerProfile)
        {
            _fetchCustomerProfile = fetchCustomerProfile;
        }
        
        [HttpGet]
        [Route("api/customer/{userName}")]
        [ProducesResponseType(typeof(FetchCustomerProfileResponse), (int)HttpStatusCode.OK)]
        public async Task<FetchCustomerProfileResponse> Get([FromBody] string userName)
        {
            var user = await _fetchCustomerProfile.Fetch(userName);
            return new FetchCustomerProfileResponse(user.Name, user.CarRents.Count);
        }
    }
}