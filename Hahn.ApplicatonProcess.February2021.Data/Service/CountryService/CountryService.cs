using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Hahn.ApplicatonProcess.February2021.Data.Request;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Country;
using Hahn.ApplicatonProcess.February2021.Data.Api.CountryApi;

namespace Hahn.ApplicatonProcess.February2021.Data.Service.CountryService
{
    public class CountryService : BaseRequest, ICountryApi, ICountryService
    {
        public CountryService()
        {
            baseUrl = Environment.GetEnvironmentVariable("baseUrlCountryApi");
        }

        public async Task<CountryExists> searchByName(string name)
        {
            try
            {
                HttpResponseMessage result = await doRequest(methods.GET, name);
                string countryJson = await result.Content.ReadAsStringAsync();
                dynamic countryData = JsonConvert.DeserializeObject<dynamic>(countryJson);
                countryData.httpStatusCode = (int)result.StatusCode;
                return countryData;
            }
            catch (Exception e)
            {
                return new CountryExists(500);
            }
        }
    }
}
