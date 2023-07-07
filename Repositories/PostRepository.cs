using backEnd.Model;

public class PostRepository : IRepository<Post>
{
    private MyCampariditContext context;
    public PostRepository(MyCampariditContext context) => this.context = context;

    public async Task Add(Post post)
    {
        await context.AddAsync(post);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Post post)
    {
        context.Remove(post);
        await context.SaveChangesAsync();
    }

    public async Task Update(Post post)
    {
        context.Update(post);
        await context.SaveChangesAsync();
    }
}
