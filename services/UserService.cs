using backEnd.Model;

public class UserService
{
    private MyCampariditContext context;

    public UserService(MyCampariditContext context)
    {
        this.context = context;
    }

    public async Task<int> GetIdByUsername(string username)
    {
        var query = context.Usuarios.Where(u => u.Usuario1 == username);

        var user = query.FirstOrDefault();
        if(user is null)
            return 0;

        return user.Id;

    }
}