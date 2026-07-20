using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Repository;

public class EventoPersistence : IEventoPersistence
{
    private readonly ProEventosContext _context;

    public EventoPersistence(ProEventosContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    // GET DOS EVENTOS
    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lote)
            .Include(e => e.RedeSocials);

        if (includePalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query.OrderBy(e => e.Id);

        return await query.ToArrayAsync();
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lote)
            .Include(e => e.RedeSocials);

        if (includePalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query
            .OrderBy(e => e.Id)
            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

        return await query.ToArrayAsync();
    }

    public async Task<Evento?> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lote)
            .Include(e => e.RedeSocials);

        if (includePalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query
            .OrderBy(e => e.Id)
            .Where(e => e.Id == eventoId);

        return await query.FirstOrDefaultAsync();
    }
}