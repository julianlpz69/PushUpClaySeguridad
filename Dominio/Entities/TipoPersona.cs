﻿using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class TipoPersona
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
