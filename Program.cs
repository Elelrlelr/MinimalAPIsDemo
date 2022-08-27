using Microsoft.EntityFrameworkCore;
using MinimalApisDemo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.UseContactApi();


// Using resoure: 
builder.Services.UseInfoApi();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
app.MapInfoApi();


app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
    c.RoutePrefix = string.Empty;
    });
app.Run();
