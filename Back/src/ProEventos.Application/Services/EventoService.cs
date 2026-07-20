using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services;

public class EventoService : IEventoService
{
    private readonly IGeralPersistence geralPersistence;
    private readonly IEventoPersistence eventoPersistence;

    public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
    {
        this.geralPersistence = geralPersistence;
        this.eventoPersistence = eventoPersistence;
    }
    public async Task<Evento?> AddEventos(Evento model)
    {
        try
        {
            geralPersistence.Add<Evento>(model);
            if (await geralPersistence.SaveChangesAsync())
            {
                return await eventoPersistence.GetAllEventoByIdAsync(model.Id, false);
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR:" + ex.Message);
        }
    }

    public async Task<Evento?> UpdateEventos(int eventoId, Evento model)
    {
        try
        {
            var evento = await eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
            if (evento == null) return null;

            model.Id = evento.Id;
            
            geralPersistence.Update(model);

            if (await geralPersistence.SaveChangesAsync())
            {
                return await eventoPersistence.GetAllEventoByIdAsync(model.Id, false);
            }
            return null;
 
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR:" + ex.Message);
        }
    }

    public async Task<bool> DeleteEventos(int eventoId)
    {
        try
        {
            var evento = await eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
            if (evento == null) throw new Exception("EVENTO PARA DELETE NÃO ENCONTRADO.");    
            geralPersistence.Delete<Evento>(evento);
            return await geralPersistence.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR:" + ex.Message);
        }
    }
    public async Task<Evento[]?> GetAllEventosAsync(bool includePalestrantes = false)
    {
        try
        {
            var eventos = await eventoPersistence.GetAllEventosAsync(includePalestrantes);
            if (eventos == null) return null;
            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR:" + ex.Message);
        }
    }

    public async Task<Evento[]?> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        try
        {
            var eventos = await eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
            if (eventos == null) return null;
            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR:" + ex.Message);
        }
    }
    public async Task<Evento?> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        try
        {
            var evento = await eventoPersistence.GetAllEventoByIdAsync(eventoId, includePalestrantes);
            if (evento == null) return null;
            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR:" + ex.Message);
        }
    }
}
