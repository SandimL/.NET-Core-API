using Hahn.ApplicatonProcess.February2021.Domain.Models.Country;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Service.CountryService
{
    public interface ICountryService
    {
        Task<CountryExists> searchByName(string name);
    }
}
