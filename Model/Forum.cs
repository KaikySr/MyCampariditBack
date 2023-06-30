using System;
using System.Collections.Generic;

namespace backEnd.Model;

public partial class Forum
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateTime? DataCriado { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
