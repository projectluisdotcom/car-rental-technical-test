using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api
{
    public class ReturnCarsRequest
    {
        [Required(ErrorMessage = "Please, provide userName")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Please, provide license number list")]
        public List<string> LicenseNumbers { get; set; }

        private ReturnCarsRequest()
        {
        }

        public ReturnCarsRequest(string userName, List<string> licenseNumbers)
        {
            UserName = userName;
            LicenseNumbers = licenseNumbers;
        }
    }
}