using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AlumnoGrado
{
    public int Id { get; set; }

    public int AlumnoId { get; set; }

    public int GradoId { get; set; }

    public string Seccion { get; set; } = null!;

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Grado Grado { get; set; } = null!;
}
