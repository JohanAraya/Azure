using ComponentesMVC._1_Entities;
using ComponentesMVC._2_Conexion.Configs;
using Microsoft.EntityFrameworkCore;

namespace ComponentesMVC._2_Conexion.Contextos
{
    public class Conexion:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Le paso la conexion
            options.UseCosmos(
                "https://appventacosmos.documents.azure.com:443/",
                "dFTvXKwLljt0YzXb78surgHeosdcglBOk4uObp7Cw5gcF1yeqDDZZ3FMKZt8mE7flzdgOhO4lEvR9HHKZJo15w==",
                "appventacosmos"
                );


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UsuarioConfig());
            builder.ApplyConfiguration(new MascotaConfig());

        }


    }
}
