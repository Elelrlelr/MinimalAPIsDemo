using Microsoft.EntityFrameworkCore;
using MinimalApisDemo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.UseContactApi();

// Using resoure: 

builder.Services.UseInfoApi();
// builder.Services.UseContactApi();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
                                { 
                                    c.SwaggerDoc("v1", new() {Title="My Minimal-OpenAPI", Version="v1"});
                                    c.SwaggerDoc("v2", new() {Title="My Future Minimal-OpenAPI", Version="v2"});
                                }
                              );


builder.Services.AddDbContext<InfoContext>(options => 
                options.UseSqlite(builder.Configuration.GetConnectionString("myDatabase")));


var app = builder.Build();
// Seeding data
using (var scope = app.Services.CreateScope())
{
    var scopedServices = scope.ServiceProvider;
    Seed.Ininial(scopedServices);
}


// Mapping api repuests:

app.MapGet("/", () => "MinimalApiDemo - Greeting...");
app.MapInfoApi();
// app.MapContactApi();


app.UseSwagger();
app.UseSwaggerUI(c =>
                    {  
                        c.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
                        c.SwaggerEndpoint("/swagger/v2/swagger.json","v2");                       
                    }
                );
app.Run();
