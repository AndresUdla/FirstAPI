using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> DevuelveInformacionEstudiante(string BannerId);
        IEnumerable<Estudiante> DevuelveListadoEstudiantes();

    }
}
