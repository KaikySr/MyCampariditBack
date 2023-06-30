using System;
using System.Collections.Generic;

namespace backEnd.Model;

public partial class Cargo
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdForum { get; set; }

    public virtual ICollection<CargosXpermisso> CargosXpermissos { get; set; } = new List<CargosXpermisso>();

    public virtual Forum IdForumNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
