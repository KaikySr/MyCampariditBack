using backEnd.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Controllers;

[EnableCors("MainPolicy")]
[ApiController]
[Route("forum")]
public class ForumController : ControllerBase
{
    private MyCampariditContext context;
    public ForumController(MyCampariditContext context) => this.context = context;

    [HttpGet("")]
    public List<ForumDTO> Get()
    {
        var query = from forum in context.Forums
        select new ForumDTO(forum.Nome, forum.Descricao);
            
        return query.ToList();
    }

    [HttpGet("{nomeForum}")]
    public List<ForumDTO> Filter(string nomeForum)
    {
        var query = from forum in context.Forums
            where forum.Nome.Contains(nomeForum)
            select new ForumDTO(forum.Nome, forum.Descricao);

        return query.ToList();
    }

    
}