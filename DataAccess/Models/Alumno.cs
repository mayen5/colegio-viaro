using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Alumno
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<AlumnoGrado> AlumnoGrados { get; set; } = new List<AlumnoGrado>();
}
