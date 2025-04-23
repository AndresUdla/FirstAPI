using FirstAPI.Interfaces;
using FirstAPI.Models;
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

        [HttpGet]
        public IActionResult DevuelveListadoEstudiantes()
        {
            var estudiantes = _estudianteRepository.DevuelveListadoEstudiantes();
            if (estudiantes != null)
            {
                return Ok(estudiantes);
            }
            return NotFound();
        }

        
        [Route("InfoEstudiante/{BannerId}")]
        [HttpGet]
        public IActionResult DevuelveInformacionEstudiante(string BannerId)
        {
            try 
            {
                var informacionEstudiante = _estudianteRepository.DevuelveInformacionEstudiante(BannerId);
                return Ok(informacionEstudiante);
            } catch (Exception ex)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult GuardarEstudiante([FromBody]Estudiante estudiante)
        {
            if (estudiante != null)
            {
                return Ok(estudiante);
            }
            return NotFound();
        }
    }
}
