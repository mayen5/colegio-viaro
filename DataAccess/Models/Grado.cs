using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Grado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int ProfesorId { get; set; }

    public virtual ICollection<AlumnoGrado> AlumnoGrados { get; set; } = new List<AlumnoGrado>();

    public virtual Profesor Profesor { get; set; } = null!;
}
