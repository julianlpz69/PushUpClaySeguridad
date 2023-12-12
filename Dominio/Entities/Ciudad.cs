﻿using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Ciudad
{
    public int Id { get; set; }

    public string? NombreCiudad { get; set; }

    public int? IdDep { get; set; }

    public virtual Departamento? IdDepNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
