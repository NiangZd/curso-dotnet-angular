namespace ProEventos.Domain.Models;
public class Lote
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required decimal Preco { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public required int Quantidade { get; set; }
    public required int EventoId { get; set; }
    public Evento? Evento { get; set; }
}