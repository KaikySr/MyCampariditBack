public class PostDTO 
{
    public string Conteudo { get; set; }

    public string Foto { get; set; }

    public string Criador { get; set; }

    public string FotoCriador { get; set; }

    public string Forum { get; set; }

    public PostDTO(string conteudo, string foto, string criador, string fotoCriador, string forumName)
    {
        Conteudo = conteudo;
        Foto = foto;
        Criador = criador;
        FotoCriador = fotoCriador;
        Forum =  forumName;
    }
}

