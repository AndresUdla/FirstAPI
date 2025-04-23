using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
    public interface IEstudianteRepository
    {
        Estudiante DevuelveInformacionEstudiante(string BannerId);
        IEnumerable<Estudiante> DevuelveListadoEstudiantes();

        Boolean GuardarEstudiante(Estudiante estudiante);

        Boolean EliminarEstudiante(string BannerId);

    }
}
