using backEnd.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Security.Jwt;

namespace backEnd.Controllers;

[EnableCors("MainPolicy")]
[ApiController]
[Route("post")]
public class PostController : ControllerBase
{
    private MyCampariditContext context;
    public PostController(MyCampariditContext context) => this.context = context;

    [HttpGet("")]
    public List<PostDTO> Get()
    {
        var query = from post in context.Posts
            join criador in context.Usuarios on post.IdCriador equals criador.Id
            select new PostDTO(post.Conteudo, post.Foto, criador.Usuario1, post.IdForumNavigation.Nome);
            
        return query.ToList();
    }

    [HttpPost("addPost")]
    public async Task<ActionResult<PostDTO>> AddPost(
        [FromBody] PostDTO data,
        [FromServices] IRepository<Post> repo,
        [FromServices] UserService userService,
        [FromServices] ForumService forumService
    )
    {
        var userId = await userService.GetIdByUsername(data.Criador);
        var forumId = await forumService.GetIdByForum(data.Forum);

        var post = new Post
        {
            Conteudo = data.Conteudo,
            IdCriador = userId,
            IdForum = forumId
        };

        await repo.Add(post);
        return Ok();
    }
}