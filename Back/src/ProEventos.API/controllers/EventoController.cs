using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public IEnumerable<Evento> _evento = new Evento[]
        {
            new Evento()
            {
                EventoId = 1,
                Tema = "Angular e .NET",
                Local = "Remoto",
                Lote = "1° Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImgURL = "FOTO.PNG"
            },
            new Evento()
            {
                EventoId = 2,
                Tema = "JAVA E REACT",
                Local = "SP",
                Lote = "2° Lote",
                QtdPessoas = 500,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImgURL = "TALFOTO.PNG"
            },
        };
    public EventoController()
    {

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(evento => evento.EventoId == id);
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