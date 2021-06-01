using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.February2021.Domain.Models.Country
{
    public class CountryExists
    {
        public int httpStatusCode { get; set; }

        public CountryExists(int httpStatusCode)
        {
            this.httpStatusCode = httpStatusCode;
        }
    }
}
