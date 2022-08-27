var builder = WebApplication.CreateBuilder(args);


builder.Services.UseContactApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
                                { c.SwaggerDoc("v1", new() {Title="My Minimal-OpenAPI", Version="v1"});
                                c.SwaggerDoc("v2", new() {Title="My Future Minimal-OpenAPI", Version="v2"});
                                    });


var app = builder.Build();


// app.UseStaticFiles();



app.MapGet("/", () => "Hello World!");
app.MapContactApi();

if(app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
                        c.SwaggerEndpoint("/swagger/v2/swagger.json","v2");
                        });
}
app.Run();
