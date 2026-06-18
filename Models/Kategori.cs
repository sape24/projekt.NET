using System.ComponentModel.DataAnnotations;

namespace projekt.NET.Models;

public class Kategori
{
    public int Id { get; set; }

    [Required]
    public string? Namn {get; set; }

    public List<Recept> Recept { get; set; } = new();
}