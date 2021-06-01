using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Data.Repository.AssetRepository;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Assets;
using Serilog;
using System;

namespace Hahn.ApplicatonProcess.February2021.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private IGenericRepository<Asset> _assets;
        private readonly AssetContext _context;

        public UnityOfWork(AssetContext assetContext)
        {
            _context = assetContext;
        }

        public IGenericRepository<Asset> Assets
        {
            get
            {
                if (_assets == null)
                {
                    _assets = new AssetRepository(_context);
                }
                return _assets;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
            Log.Information("Saved changes");
        }

        public void Dispose()
        {
            if(_context != null) _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
