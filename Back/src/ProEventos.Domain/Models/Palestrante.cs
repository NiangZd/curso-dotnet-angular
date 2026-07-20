namespace ProEventos.Domain.Models;

public class Palestrante
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string MiniCurriculo { get; set; }
    public required string ImagemURL { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }

    public ICollection<RedeSocial> RedeSocials { get; set; } = [];
    public ICollection<PalestranteEvento> PalestrantesEventos { get; set; } = [];
}