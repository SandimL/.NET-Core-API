using Hahn.ApplicatonProcess.February2021.Domain.Models.Assets;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository.AssetRepository
{
    public class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options) : base(options)
        { Database.EnsureCreated(); }

        public DbSet<Asset> Assets { get; set; }
    }
}
