using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MinimalApisDemo.Models;

public class InfoRepository
{
       public static async Task<List<Info>?> GetAllInfo(InfoContext ctx) =>  await ctx.Info.ToListAsync();
  
}