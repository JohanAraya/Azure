using ComponentesMVC._1_Entities;
using ComponentesMVC._1_Entities.Interfaces.Repositorios;
using ComponentesMVC._3_Servicios.Interfaces;

namespace ComponentesMVC._3_Servicios.Servicios
{
    public class UsuarioServicio : IServicioBase<Usuario, Guid>
    {
        private readonly IRepositorioBase<Usuario, Guid> repoUsuario;

        public UsuarioServicio(IRepositorioBase<Usuario, Guid> _repoUsuario)
        {
            repoUsuario = _repoUsuario;
        }
        public Usuario Agregar(Usuario entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException("El 'Producto' es requerido");
            }

            var resultUsuario = repoUsuario.Agregar(entidad);
            repoUsuario.guardarTodosLosCambios();
            return resultUsuario;
        }

        public void Editar(Usuario tentidad)
        {
            if (tentidad == null)
            {
                throw new ArgumentNullException("El 'Producto' es requerido para editar");
            }

            repoUsuario.Editar(tentidad);
            repoUsuario.guardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoUsuario.Eliminar(entidadId);
            repoUsuario.guardarTodosLosCambios();
        }

        public List<Usuario> Listar()
        {
            return repoUsuario.Listar();
        }

        public Usuario seleccionarPorId(Guid entidadId)
        {
            return repoUsuario.seleccionarPorId(entidadId);
        }
    }
}
