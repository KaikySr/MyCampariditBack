using System;
using System.Collections.Generic;

namespace backEnd.Model;

public partial class CargosXpermisso
{
    public int Id { get; set; }

    public int IdCargo { get; set; }

    public int IdPermissoes { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Permisso IdPermissoesNavigation { get; set; } = null!;
}
