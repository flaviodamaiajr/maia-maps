using Maia.Maps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maia.Maps.Infra.Data.Context
{
    public class MaiaContext : DbContext
    {
        #region DBSets

        public DbSet<SearchHistory> SearchHistories { get; set; }

        #endregion

        public MaiaContext(DbContextOptions<MaiaContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaiaContext).Assembly);
        }

    }
}
