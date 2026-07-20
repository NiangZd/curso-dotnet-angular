using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces;
public interface IEventoPersistence
{
    // EVENTOS 
    Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
    Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento?> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false);
}
