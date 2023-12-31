﻿using DataAccess.Models;
using DataAccess.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO alumnoDAO = new AlumnoDAO();

        [HttpGet("alumnosProfesor")]
        public List<AlumnosPorProfesor> getAlumnosPorProfesorId( int profesorId)
        {
            return alumnoDAO.selectAlumnosProfesor(profesorId);
        }

        [HttpGet("alumno")]
        public Alumno getAlumno(int id)
        {
            return alumnoDAO.selectAlumno(id);
        }

        [HttpPut("alumno")]
        public bool updateAlumno([FromBody] Alumno alumno)
        {
            return alumnoDAO.updateAlumno(
                alumno.Id,
                alumno.Nombre,
                alumno.Apellidos,
                alumno.Genero,
                alumno.FechaNacimiento
            );
        }

        [HttpPost("alumnoGrado")]
        public bool insertAlumnoGrado([FromBody]Alumno alumno, int gradoId, string seccion)
        {
            return alumnoDAO.insertAlumnoGrado(alumno.Id, alumno.Nombre, alumno.Apellidos, alumno.Genero, alumno.FechaNacimiento, gradoId, seccion);
        }

        [HttpDelete("alumno")]
        public bool deleteAlumno( int id)
        {
            return alumnoDAO.deleteAlumnoAll(id);
        }

    }
}
