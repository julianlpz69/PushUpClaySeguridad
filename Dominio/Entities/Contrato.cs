﻿using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Contrato
{
    public int Id { get; set; }

    public DateOnly? FechaContrato { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdEstado { get; set; }

    public virtual Persona? IdClienteNavigation { get; set; }

    public virtual Persona? IdEmpleadoNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual ICollection<Programacion> Programacions { get; } = new List<Programacion>();
}
