using System;
using System.Collections.Generic;

namespace CRUDUSUARIOS3.Models;

public partial class Usuarios3
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Clave { get; set; }
}
