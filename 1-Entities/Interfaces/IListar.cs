namespace ComponentesMVC._1_Entities.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        TEntidad seleccionarPorId(TEntidadID entidadId);
    }
}
