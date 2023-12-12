﻿using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Estado
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Contrato> Contratos { get; } = new List<Contrato>();
}
