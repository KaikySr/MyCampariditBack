// using backEnd.Model;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Security.Jwt;

// namespace backEnd.Controllers;

// [EnableCors("MainPolicy")]
// [ApiController]
// [Route("user")]
// public class UserController : ControllerBase
// {
//     private MyCampariditContext context;
//     public UserController(MyCampariditContext context) => this.context = context;

//     [HttpGet("")]
//     public List<UserDTO> Get
//     (
//         // [FromServices]JwtService jwt
//     )
//     {
        

//         // var query = from user in context.Users
//         //     join criador in context.Usuarios on post.IdCriador equals criador.Id
//         //     select new UserDTO();
            
//         // return query.ToList();
//     }

    
// }