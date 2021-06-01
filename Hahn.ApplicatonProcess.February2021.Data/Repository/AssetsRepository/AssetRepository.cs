using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Assets;
using System.Linq;
using Serilog;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository.AssetRepository
{
    public class AssetRepository : DbContext, IGenericRepository<Asset>
    {
        private readonly AssetContext _context;

        public AssetRepository(AssetContext assetContext)
        {
            Log.Information($"Started a new AssetRepository");
            _context = assetContext;
        }

        public async Task<Asset> Get(int id)
        {
            Log.Information($"Id of the asset searched: {id}");
            Asset assetFound = await _context.Assets.FirstOrDefaultAsync(x => x.ID == id);
            if(assetFound != null)
            {
                Log.Information($"Asset found: { assetFound.ToJson() }");
            }
            else
            {
                Log.Information("Asset not found");
            }
            
            return assetFound;
        }

        public async Task Add(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            
            Log.Information($"Asset added: {asset.ToJson()}");
        }

        public async Task Update(Asset asset)
        {
            var assetFound = await _context.Assets.FindAsync(asset);
            this._context.Entry(assetFound).CurrentValues.SetValues(asset);

            if (assetFound != null)
            {
                Log.Information($"Asset updated: {asset.ToJson()}");
            }
            else
            {
                Log.Information("Asset not found");
            }
        }

        public void Delete(int id)
        {
            var asset = _context.Assets.FirstOrDefault(x => x.ID == id);
            _context.Assets.Remove(asset);
            Log.Information($"Asset deleted: {asset.ToJson()}");
        }
    }
}
