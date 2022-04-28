using ComponentesMVC._1_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComponentesMVC._2_Conexion.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuarios");
            //builder.HasNoKey();
            builder.HasKey(c => c._id);
            //builder.HasNoKey(Mascota);
            builder.HasAlternateKey(usuario => usuario.correo);



        }
    }
}
