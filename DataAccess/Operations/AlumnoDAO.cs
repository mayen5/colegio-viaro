﻿using DataAccess.Context;
using DataAccess.Models;

namespace DataAccess.Operations
{
    public class AlumnoDAO
    {
        public ColegioContext contexto = new ColegioContext();

        public List<Alumno> selectAll()
        {
            var alumnos = contexto.Alumnos.ToList();
            return alumnos;
        }

        public Alumno selectAlumno(int id)
        {
            var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();

            return alumno;
        }

        public bool insertAlumno(string nombre, string apellidos, string genero, DateTime fechaNacimiento)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Nombre = nombre;
                alumno.Apellidos = apellidos;
                alumno.Genero = genero;
                alumno.FechaNacimiento = fechaNacimiento;

                contexto.Alumnos.Add(alumno);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updateAlumno(int id, string nombre, string apellidos, string genero, DateTime fechaNacimiento)
        {
            try
            {

                var alumno = selectAlumno(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    alumno.Nombre = nombre;
                    alumno.Apellidos = apellidos;
                    alumno.Genero = genero;
                    alumno.FechaNacimiento = fechaNacimiento;

                    contexto.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool deleteAlumno(int id)
        {

            try
            {
                var alumno = selectAlumno(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<AlumnosPorGrado> selectAlumnosPorGrado()
        {
            var query = from a in contexto.Alumnos
                        join ag in contexto.AlumnoGrados on a.Id equals ag.AlumnoId
                        join g in contexto.Grados on ag.GradoId equals g.Id
                        select new AlumnosPorGrado
                        {
                            NombreAlumno = a.Nombre,
                            ApellidosAlumno = a.Apellidos,
                            NombreGrado = g.Nombre
                        };
            return query.ToList();
        }

        public List<AlumnosPorProfesor> selectAlumnosProfesor(int profesorId)
        {
            var query = from a in contexto.Alumnos
                        join ag in contexto.AlumnoGrados on a.Id equals ag.AlumnoId
                        join g in contexto.Grados on ag.GradoId equals g.Id
                        where g.ProfesorId == profesorId
                        select new AlumnosPorProfesor
                        {
                            Id = a.Id,

                            Nombre = a.Nombre,
                            Apellidos = a.Apellidos,
                            Genero = a.Genero,
                            FechaNacimiento = a.FechaNacimiento.ToShortDateString(),
                            Grado = g.Nombre
                        };
            return query.ToList();
        }

        public bool insertAlumnoGrado(int alumnoId, string nombreAlumno, string apellidosAlumno, string generoAlumno, DateTime fechaNacimientoAlumno, int gradoId, string seccion)
        {
            try
            {
                var existsAlumno = selectAlumno(alumnoId);

                if (existsAlumno == null)
                {
                    insertAlumno(nombreAlumno, apellidosAlumno, generoAlumno, fechaNacimientoAlumno);
                    var insert = selectAlumno(alumnoId);
                    AlumnoGrado alumnoGrado = new AlumnoGrado();
                    alumnoGrado.AlumnoId = insert.Id;
                    alumnoGrado.GradoId = gradoId;
                    alumnoGrado.Seccion = seccion;
                    contexto.AlumnoGrados.Add(alumnoGrado);
                    contexto.SaveChanges();
                    return true;

                }
                else
                {
                    AlumnoGrado alumnoGrado = new AlumnoGrado();
                    alumnoGrado.AlumnoId = existsAlumno.Id; 
                    alumnoGrado.GradoId = gradoId;
                    alumnoGrado.Seccion = seccion;
                    contexto.AlumnoGrados.Add(alumnoGrado);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool deleteAlumnoAll(int id)
        {
            try
            {
                var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();

                if (alumno != null)
                {

                    var alumnoGrado = contexto.AlumnoGrados.Where(ag => ag.AlumnoId == id).FirstOrDefault();
                    contexto.AlumnoGrados.Remove(alumnoGrado);
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();


                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
