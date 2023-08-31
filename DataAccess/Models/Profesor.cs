using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Profesor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public virtual ICollection<Grado> Grados { get; set; } = new List<Grado>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
