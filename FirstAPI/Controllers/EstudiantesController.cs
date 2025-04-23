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
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult GuardarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                if (estudiante != null)
                {
                    var guardado = _estudianteRepository.GuardarEstudiante(estudiante);
                    if (guardado)
                    {
                        return Ok("Estudiante guardado correctamente");
                    }
                    else
                    {
                        return BadRequest("Error al guardar el estudiante");
                    }
                }
                else
                {
                    return BadRequest("El estudiante no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        [HttpDelete]
        [Route("EliminarEstudiante/{BannerId}")]
        public IActionResult EliminarEstudiante(string BannerId)
        {
            try
            {
                var eliminado = _estudianteRepository.EliminarEstudiante(BannerId);
                if (eliminado)
                {
                    return Ok("Estudiante eliminado correctamente");
                }
                else
                {
                    return NotFound("No se encontró el estudiante");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }
    }
}
