using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Models;
using ProEventos.Application.Interfaces;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{

    private readonly IEventoService eventoService;

    public EventosController(IEventoService eventoService)
    {
        this.eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await eventoService.GetAllEventosAsync(true);
            if (eventos == null) return NotFound("NENHUM EVENTO ENCONTRADO");
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "ERROR REC EVENTOS: " + ex.Message
            );
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var evento = await eventoService.GetAllEventoByIdAsync(id, true);
            if (evento == null) return NotFound("EVENTO POR ID NÃO ENCONTRADO");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "ERROR REC EVENTO ID: " + ex.Message
            );
        }
    }

    [HttpGet("tema/{tema}")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = await eventoService.GetAllEventosByTemaAsync(tema, true);
            if (eventos == null) return NotFound("EVENTOS POR TEMA NÃO ENCONTRADOS");
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "ERROR REC EVENTO BY TEMA: " + ex.Message
            );
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await eventoService.AddEventos(model);
            if (evento == null) return BadRequest("ERRO AO TENTAR ADICIONAR EVENTO");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "ERROR ADD EVENTO: " + ex.Message
            );
        }
    }   

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await eventoService.UpdateEventos(id, model);
            if (evento == null) return BadRequest("ERRO AO TENTAR ATUALIZAR EVENTO");
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "ERROR UPDATE EVENTO: " + ex.Message
            );
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return await eventoService.DeleteEventos(id) ?
                    Ok("DELETADO") : 
                    BadRequest("EVENTO NÃO DELETADO");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "ERROR DELETE EVENTO: " + ex.Message
            );
        }
    }
}