public class ForumDTO 
{
    public string Nome { get; set; }

    public string Descricao { get; set; }

    public ForumDTO(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }
}

