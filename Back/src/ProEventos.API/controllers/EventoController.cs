using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    private readonly DataContext context;
    public EventoController(DataContext context)
    {
            this.context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return context.Evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return context.Evento.Where(evento => evento.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "POST";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"Aqui meu Id: {id}";
    }
}