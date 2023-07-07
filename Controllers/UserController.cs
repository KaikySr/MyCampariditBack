using backEnd.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Security.Jwt;

namespace backEnd.Controllers;

[EnableCors("MainPolicy")]
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private MyCampariditContext context;
    public UserController(MyCampariditContext context) => this.context = context;

    [HttpGet("")]
    public List<UserDTO> Get
    (
        [FromServices]JwtService jwt
    )
    {
        return new List<UserDTO>();
        // var query = from user in context.Users
        //     join criador in context.Usuarios on post.IdCriador equals criador.Id
        //     select new UserDTO();
            
        // return query.ToList();
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserDTO>> SignUp(
        [FromBody] CreateUserDTO data,
        [FromServices] IRepository<Usuario> repo
    )
    {

        var user = new Usuario
        {
            Email = data.Email,
            Usuario1 = data.Username,
            Senha = data.Password
        };

        await repo.Add(user);
        return Ok();
    }

//     [HttpPost("signin")]
// //   public async Task<ActionResult<UserDTO>> SignIn(
//     [FromBody] CreateUserDTO userData,
//     [FromServices] UserRepository repo
//   )
//   {

//     if(userData.Email == )
//     // var user = await repo.GetUserByUsername(userData.Username);

//     // if(user is null)
//     //   return BadRequest("Nome de usuário incorreto.");
    
//     // var passwordHash = security.ApplyHash(userData.Password, user.Salt);

//     // if(passwordHash != user.Password)
//     //   return BadRequest("Senha incorreta.");

//     // var userToken = new UserToken
//     // {
//     //   Id = user.Id,
//     //   Username = user.Username,
//     //   Email = user.Email,
//     //   Born = user.Born,
//     //   PhotoID = user.Photo,
//     //   Authenticated = true
//     // };
    
//     // var token = jwt.GenerateToken(userToken);
//     // return Ok(new Jwt{ Value = token });
//   }

}