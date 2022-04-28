using ComponentesMVC._1_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComponentesMVC._2_Conexion.Configs
{
    public class MascotaConfig : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {

            builder.ToTable("Mascotas");
            builder.HasKey(c => c._id);
            builder.HasAlternateKey(mascota => mascota.correoUsuraio);
        }
    }
}
