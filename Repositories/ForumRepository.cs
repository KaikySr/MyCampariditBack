using backEnd.Model;

public class ForumRepository : IRepository<Forum>
{
    private MyCampariditContext context;
    public ForumRepository(MyCampariditContext context) => this.context = context;

    public async Task Add(Forum forum)
    {
        await context.AddAsync(forum);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Forum forum)
    {
        context.Remove(forum);
        await context.SaveChangesAsync();
    }

    public async Task Update(Forum forum)
    {
        context.Update(forum);
        await context.SaveChangesAsync();
    }
}
