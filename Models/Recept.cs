using System.ComponentModel.DataAnnotations;

namespace projekt.NET.Models;

public class Recept
{
    public int Id { get; set; }

    [Required]
    public string? Titel { get; set; }

    public string? Beskrivning { get; set; }

    public string? Instruktioner { get; set; }

    public int Tillagningstid { get; set; }

    public int KategoriId { get; set; }
    public Kategori? Kategori { get; set; }

    public List <Ingrediens> Ingredienser { get; set; } = new();
}