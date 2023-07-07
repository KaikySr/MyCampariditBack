using backEnd.Model;

public class UserRepository : IRepository<Usuario>
{
    private MyCampariditContext context;
    public UserRepository(MyCampariditContext context) => this.context = context;

    public async Task Add(Usuario user)
    {
        await context.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Usuario user)
    {
        context.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task Update(Usuario user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
    }

    internal Task GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }
}
