namespace ProEventos.Domain.Models;

public class Evento
{
    public int Id { get; set; }
    public required string Local { get; set; }
    public DateTime? DataEvento { get; set; }
    public required string Tema { get; set; }
    public required int QtdPessoas { get; set; }
    public required string ImgURL { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }

    public ICollection<Lote> Lote { get; set; } = [];
    public ICollection<RedeSocial> RedeSocials { get; set; } = [];
    public ICollection<PalestranteEvento> PalestrantesEventos { get; set; } = [];
}