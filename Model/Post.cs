using System;
using System.Collections.Generic;

namespace backEnd.Model;

public partial class Post
{
    public int Id { get; set; }

    public int IdCriador { get; set; }

    public int IdForum { get; set; }

    public int? Likes { get; set; }

    public string? Titulo { get; set; }

    public string? Conteudo { get; set; }

    public string? Foto { get; set; }

    public virtual Usuario IdCriadorNavigation { get; set; } = null!;

    public virtual Forum IdForumNavigation { get; set; } = null!;
}
