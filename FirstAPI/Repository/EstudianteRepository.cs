using FirstAPI.Interfaces;
using FirstAPI.Models;

namespace FirstAPI.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        public Estudiante DevuelveInformacionEstudiante(string BannerId)
        {
            var estudiantes = DevuelveListadoEstudiantes();
            return estudiantes.First(item => item.BannerId == BannerId); // Use 'Where' to return an IEnumerable  
        }

        public IEnumerable<Estudiante> DevuelveListadoEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            Estudiante estudiante1 = new Estudiante()
            {
                BannerId = "123456",
                Nombre = "Juan Perez",
                Edad = 20,
                TieneBeca = true
            };

            estudiantes.Add(estudiante1);

            Estudiante estudiante2 = new Estudiante()
            {
                BannerId = "654321",
                Nombre = "Maria Lopez",
                Edad = 22,
                TieneBeca = false
            };
            estudiantes.Add(estudiante2);

            return estudiantes;
        }

        public bool EliminarEstudiante(string BannerId)
        {
            //logica del negocio
            return true;
        }

        public Boolean GuardarEstudiante(Estudiante estudiante)
        {
            if (estudiante != null)
            {
                return true;
            }
            return false;
        }


    }
}
