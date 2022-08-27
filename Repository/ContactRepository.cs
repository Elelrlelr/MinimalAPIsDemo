

using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MinimalApisDemo.Models;

public class ContactRepository
{
    public IEnumerable<Contact>? Get()
    {
        return JsonSerializer.Deserialize<IEnumerable<Contact>>(File.OpenRead("wwwroot/contacts.json"));
        
    }

    internal Contact? GetById(int id)
    {
        return JsonSerializer.Deserialize<IEnumerable<Contact>>(File.OpenRead("wwwroot/contacts.json"))?.FirstOrDefault(c => c.Id == id);
    }

    
}