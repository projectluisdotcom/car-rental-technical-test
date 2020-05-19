using System;
using System.Collections.Generic;

namespace Domain
{
    public class ReturnRequest
    {
        public readonly string UserName;
        public readonly IEnumerable<string> LicenseNumbers;
        public readonly DateTime Now;

        public ReturnRequest(string userName, IEnumerable<string> licenseNumbers, DateTime now)
        {
            UserName = userName;
            LicenseNumbers = licenseNumbers;
            Now = now;
        }
    }
}