using System.ComponentModel.DataAnnotations;

namespace sharp.Models
{
    public record struct BlogsViewModel(string Id, string Name, string Description, string WebsiteUrl, DateTime CreatedAt);
    
}
