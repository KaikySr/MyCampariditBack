public class PostDTO 
{
    public string Titulo { get; set; }

    public string Conteudo { get; set; }

    public string Foto { get; set; }

    public string Criador { get; set; }

    public string FotoCriador { get; set; }

    public PostDTO(string titulo, string conteudo, string foto, string criador, string fotoCriador)
    {
        Titulo = titulo;
        Conteudo = conteudo;
        Foto = foto;
        Criador = criador;
        FotoCriador = fotoCriador;
    }
}

