using backEnd.Model;

public class ForumService
{
    private MyCampariditContext context;

    public ForumService(MyCampariditContext context)
    {
        this.context = context;
    }

    public async Task<int> GetIdByForum(string nome)
    {
        var query = context.Forums.Where(f => f.Nome == nome);

        var forum = query.FirstOrDefault();
        if(forum is null)
            return 0;

        return forum.Id;

    }
}