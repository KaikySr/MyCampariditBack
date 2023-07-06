public class UserDTO 
{
    public int ID { get; set; }

    public string Foto { get; set; }

    public string Usuario { get; set;}

    public UserDTO(int id, string foto, string usuario)
    {
        ID = id;
        Foto = foto;
        Usuario = usuario;
    }
}

