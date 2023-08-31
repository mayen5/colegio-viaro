using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Login
{
    public string Usuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int? ProfesorId { get; set; } = null;

    public string? Email { get; set; } = null!;

    public virtual Profesor? Profesor { get; set; } = null!;
}
