


// app.UseStaticFiles();




public static class ContactApiExtention
{
    public static IServiceCollection UseContactApi(this IServiceCollection services)
    {
        services.AddTransient<ContactRepository>();
        return services;
    } 
    public static WebApplication MapContactApi(this WebApplication app)
    {
        app.MapGet("/contacts",
        (ContactRepository repository) =>
        {
            var contacts = repository.Get();
            return Results.Ok(contacts);
        });
        

        app.MapGet("/contacts/{id:int}",
        (int id, ContactRepository repository) =>
        {
            // Contact? value = repository.GetById(id);
            Contact? value = repository.GetById(id);
            if (value == null)
            {
                return Results.NoContent();
            }
            return Results.Ok(value);
        });

        return app;

    }
}
