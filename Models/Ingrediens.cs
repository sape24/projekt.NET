using System.ComponentModel.DataAnnotations;

namespace projekt.NET.Models;

public class Ingrediens
{
    public int Id { get; set; }

    [Required]
    public string? Namn { get; set; }

    public string? Mängd { get; set; }

    public string? Enhet { get; set; }

    public int ReceptId { get; set; }
    public Recept? Recept { get; set; }
}