using backEnd;
using backEnd.Model;
using backEnd.Controllers;

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

var app = builder.Build();


app.UseCors();
// app.UseSwagger(); // Swagger for debug
// app.UseSwaggerUI(); // Swagger for debug

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
