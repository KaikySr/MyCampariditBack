using backEnd;
using backEnd.Model;
using backEnd.Controllers;

using Security.Jwt;

// PasswordProvider pass = new PasswordProvider("minha senha");
// JwtService jwt = new JwtService(pass);

// Usuario usuario = new Usuario();
// usuario.ID = 4;
// usuario.IsAdmin = true;

// var token = jwt.GetToken(usuario);
// Console.WriteLine(token);

// try
// {
//     var result = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJc0FkbWluIjp0cnVlLCJJRCI6Mn0.GLXWUV3gKMSgP5RdzMYT6Rr9739X3hF5sH74aMG4wvY";
//     var obj = jwt.Validate<Usuario>(result);
//     Console.WriteLine(obj.ID);
// }
// catch
// {
//     Console.WriteLine("Jwt inválido");
// }

// public class Usuario
// {
//     public bool IsAdmin { get; set; }
//     public int ID { get; set; }
// }

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.AddScoped<MyCampariditContext>(); // Shared Context
builder.Services.AddTransient<PostController>(); // Create class every req

builder.Services.AddTransient<IRepository<Usuario>, UserRepository>();

builder.Services.AddTransient<JwtService>();
builder.Services.AddTransient<IPasswordProvider, PasswordProvider>(
    p => new PasswordProvider("asdfasdeubfqubdc")
);

var app = builder.Build();


app.UseCors();
// app.UseSwagger(); // Swagger for debug
// app.UseSwaggerUI(); // Swagger for debug

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
