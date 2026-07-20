namespace ProEventos.Domain.Models;
public class PalestranteEvento
{
    public required int PalestranteId { get; set; }
    public required Palestrante Palestrante { get; set; }
    public required int EventoId { get; set; }
    public required Evento Evento { get; set; }
}