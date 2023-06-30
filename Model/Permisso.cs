using System;
using System.Collections.Generic;

namespace backEnd.Model;

public partial class Permisso
{
    public int Id { get; set; }

    public int? VerPost { get; set; }

    public int? Postar { get; set; }

    public int? DarLike { get; set; }

    public int? DarDeslike { get; set; }

    public int? RemoverPost { get; set; }

    public int? RemoverMembros { get; set; }

    public int? EditarPosts { get; set; }

    public int? PromoverMembros { get; set; }

    public int? CriarEditarCargos { get; set; }

    public int? DeletarForum { get; set; }

    public virtual ICollection<CargosXpermisso> CargosXpermissos { get; set; } = new List<CargosXpermisso>();
}
