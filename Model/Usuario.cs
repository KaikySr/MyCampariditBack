using System;
using System.Collections.Generic;

namespace backEnd.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime DataNasc { get; set; }

    public string? Foto { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
