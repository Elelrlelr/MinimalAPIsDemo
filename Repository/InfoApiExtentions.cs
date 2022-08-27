using Microsoft.EntityFrameworkCore;
using MinimalApisDemo.Models;

public static class InfoApiExtention
{
    public static IServiceCollection UseInfoApi(this IServiceCollection services)
    {
        services.AddTransient<InfoRepository>();
        return services;
    }

    public static WebApplication MapInfoApi(this WebApplication app)
    {
        app.MapGet("/info", async (InfoContext ctx) =>
                    await ctx.Info.ToListAsync());

        app.MapGet("/info/{id:int}", async (InfoContext ctx, int id) =>
                    await ctx.Info.FindAsync(id) is Info info ? Results.Ok(info) : Results.NotFound("Wrong input! :/"));

        app.MapPost("/info", async (InfoContext ctx, Info info) =>
                    {
                        ctx.Info.Add(info);
                        await ctx.SaveChangesAsync();
                        return Results.Ok(await GetAllInfo(ctx));
                    });

        app.MapPut("/info/{id:int}", async (InfoContext ctx, Info info, int id) =>
                    {
                        var dbInfo = await ctx.Info.FindAsync(id);
                        if (dbInfo == null) return Results.NotFound("No info found. :(");

                        dbInfo.Name = info.Name;
                        dbInfo.Age = info.Age;
                        dbInfo.Location = info.Location;
                        dbInfo.House = info.House;
                        dbInfo.Sigil = info.Sigil;
                        await ctx.SaveChangesAsync();

                        return Results.Ok(await GetAllInfo(ctx));
                    });

        app.MapDelete("/info/{id:int}", async (InfoContext ctx, int id) =>
                    {
                        var dbInfo = await ctx.Info.FindAsync(id);
                        if (dbInfo == null) return Results.NotFound("Ur info you chose to delete not exist!");

                        ctx.Info.Remove(dbInfo);
                        await ctx.SaveChangesAsync();

                        return Results.Ok(await GetAllInfo(ctx));

                    });

        return app;
    }

    private static Task<object?> GetAllInfo(InfoContext ctx)
    {
        throw new NotImplementedException();
    }
}