using Hahn.ApplicatonProcess.February2021.Domain.Models.Country;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Api.CountryApi
{
    public interface ICountryApi
    {
        Task<CountryExists> searchByName(string name); 
    }
}
