using Microsoft.EntityFrameworkCore;
using MinimalApisDemo.Models;

public class Seed
{
    public static void Ininial(IServiceProvider service)
    {
        using (var ctx = new InfoContext(service.GetRequiredService<DbContextOptions<InfoContext>>()))
        {
            if(ctx.Info.Any())
            {
                return;
            }
            ctx.Info.AddRange(
                new Info
                {
                    Name = "John Snow",
                    Age = 21,
                    Location = "Winterfell",
                    House = "Stark",
                    Sigil = "A running grey direwolf, on an ice-white field"
                },
                new Info
                {
                    Name = "Tyrion - The Imp",
                    Age = 37,
                    Location = "Casterly Rock",
                    House = "Lannister",
                    Sigil = "A roaring lion, gold on crimson"
                },
                new Info
                {
                    Name = "Daenerys Targaryen - Mother of Dragons",
                    Age = 22,
                    Location = "King's landing",
                    House = "Targaryen",
                    Sigil = "A red three-headed dragon, breathing flame on black"
                },
                new Info
                {
                    Name = "Prince Oberyn - The Red Viper",
                    Age = 38,
                    Location = "Dorne",
                    House = "Martell",
                    Sigil = "A red sun pierced by a golden spear on orange"
                },
                new Info
                {
                    Name = "Theon Greyjoy",
                    Age = 23,
                    Location = "Iron Islands",
                    House = "Greyjoy",
                    Sigil = "A golden kraken on black"
                },
                new Info
                {
                    Name = "Jon Arryn",
                    Age = 15,
                    Location = "Gulltown",
                    House = "Arryn",
                    Sigil = "A sky-blue falcon soaring against a white moon, on sky-blue"
                },
                new Info
                {
                    Name = "Olenna - The Queen of Thorns",
                    Age = 62,
                    Location = "Highgarden",
                    House = "Tyrell",
                    Sigil = "A golden rose on green"
                },
                new Info
                {
                    Name = "Robert - The King",
                    Age = 52,
                    Location = "Storm's End",
                    House = "Baratheon",
                    Sigil = "A crowned stag black on a golden field"
                },
                new Info
                {
                    Name = "Lord Edmure Tully",
                    Age = 49,
                    Location = "Riverrun",
                    House = "Tully",
                    Sigil = "A silver trout leaping on a red chief, over white waves and a blue base"
                }
            );
            ctx.SaveChanges();
        }
    }
}