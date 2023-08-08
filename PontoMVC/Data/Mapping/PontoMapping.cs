using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoMVC.Models;

namespace PontoMVC.Data.Mapping
{
    public class PontoMapping : IEntityTypeConfiguration<PontoModel>
    {
        public void Configure(EntityTypeBuilder<PontoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Data)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(p => p.Usuario);

            builder.ToTable("Pontos");
        }
    }
}
