using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Assets;

namespace Hahn.ApplicatonProcess.February2021.Data.UnityOfWork
{
    public interface IUnityOfWork
    {
        IGenericRepository<Asset> Assets { get; }
        void Commit();
    }
}
