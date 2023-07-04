using backEnd.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        // Query pra pegar um PostDTO
        // Titulo Conteudo... de Posts
        // Criador e FotoCriador de Usuarios

        var query = from post in context.Posts 
            join criador in context.Usuarios on post.IdCriador equals criador.Id
            select new PostDTO(post.Conteudo, post.Foto, criador.Usuario1, criador.Foto);
            
        return query.ToList();
    }

    
}