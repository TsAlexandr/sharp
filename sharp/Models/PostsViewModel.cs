using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace sharp.Models
{
    public record struct PostsViewModel(string Id, string Title, string ShortDescription, string Content, string BlogId, string BlogName, DateTime CreatedAt);
}
