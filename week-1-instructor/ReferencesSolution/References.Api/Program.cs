
using Marten;
using References.Api.External;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("links")
    ?? throw new Exception("No Connection String");


// Add services to the container. 


builder.Services.AddMarten(config =>
{
    config.Connection(connectionString);
}).UseLightweightSessions(); // there will be an IDocumentSession available to use in your controllers.

builder.Services.AddScoped<IValidateLinksWithSecurity, FakeLinkValidator>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();


app.MapControllers();  // Reflection the ability to have code that looks at itself.

app.Run();


// I will explain this in detail later and you will be bored as heck.

// in .NET 10 (Sept 2025) you won't have to do this any more.
public partial class Program;
