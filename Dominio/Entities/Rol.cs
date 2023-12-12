using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string RolName { get; set; } = null!;
    public ICollection<UsuarioRol> UsuariosRols { get; set;}
    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
