using Maia.Maps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maia.Maps.Infra.Data.Mappings
{
    public class SearchHistoryMap : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.PostCode,
            navigationBuilder =>
            {
                navigationBuilder.Property(postCode => postCode.From)
                                 .HasMaxLength(15);
                navigationBuilder.Property(postCode => postCode.To)
                                 .HasMaxLength(15);
            });

            builder.OwnsOne(x => x.CoordinatesFrom,
                navigationBuilder =>
                {
                    navigationBuilder.Property(coord => coord.Latitude);
                    navigationBuilder.Property(coord => coord.Longitude);                                       
                });

            builder.OwnsOne(x => x.CoordinatesTo,
                navigationBuilder =>
                {
                    navigationBuilder.Property(coord => coord.Latitude);
                    navigationBuilder.Property(coord => coord.Longitude);
                });

            builder.OwnsOne(x => x.Distance,
                navigationBuilder =>
                {
                    navigationBuilder.Property(dist => dist.Kilometers).HasPrecision(10, 2);
                    navigationBuilder.Property(dist => dist.Miles).HasPrecision(10, 2);
                });
        }
    }
}
