using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces;
public interface IPalestrantePersistence
{
    // PALESTRANTES
    Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string name, bool includeEventos);
    Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
    Task<Palestrante?> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos);
}
