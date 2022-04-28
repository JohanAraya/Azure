using ComponentesMVC._1_Entities;
using ComponentesMVC._1_Entities.Interfaces.Repositorios;
using ComponentesMVC._3_Servicios.Interfaces;

namespace ComponentesMVC._3_Servicios.Servicios
{
    public class MascotaServicio : IServicioBase<Mascota, Guid>
    {

        private readonly IRepositorioBase<Mascota, Guid> repoMascota;

        public MascotaServicio(IRepositorioBase<Mascota, Guid> _repoMascota)
        {
            repoMascota = _repoMascota;
        }
        public Mascota Agregar(Mascota entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException("La mascota es requerida");
            }

            var resultMascota = repoMascota.Agregar(entidad);
            repoMascota.guardarTodosLosCambios();
            return resultMascota;
        }

        public void Editar(Mascota tentidad)
        {
            if (tentidad == null)
            {
                throw new ArgumentNullException("La mascota es requerida para editar");
            }

            repoMascota.Editar(tentidad);
            repoMascota.guardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoMascota.Eliminar(entidadId);
            repoMascota.guardarTodosLosCambios();
        }

        public List<Mascota> Listar()
        {
            return repoMascota.Listar();
        }

        public Mascota seleccionarPorId(Guid entidadId)
        {
            return repoMascota.seleccionarPorId(entidadId);
        }
    }
}
