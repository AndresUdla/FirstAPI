using FirstAPI.Interfaces;
using FirstAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        IEstudianteRepository _estudianteRepository;

        public EstudiantesController()
        {
            _estudianteRepository = new EstudianteRepository();
        }

        public IActionResult DevuelveListadoEstudiantes()
        {
            var estudiantes = _estudianteRepository.DevuelveListadoEstudiantes();
            if (estudiantes != null)
            {
                return Ok(estudiantes);
            }
            return NotFound();
        }

        public IActionResult DevuelveInformacionEstudiante(string BannerId)
        {
            try 
            {
                var informacionEstudiante = _estudianteRepository.DevuelveInformacionEstudiante(BannerId);
                return Ok(informacionEstudiante);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
