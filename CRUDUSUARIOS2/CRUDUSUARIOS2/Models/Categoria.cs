﻿using System;
using System.Collections.Generic;

namespace CRUDUSUARIOS2.Models;

public partial class Categoria
{
    public int CodigoCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}