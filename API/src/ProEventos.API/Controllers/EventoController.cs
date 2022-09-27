using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento;
        
        public EventoController()
        {
            _evento = new Evento[] 
                        {
                            new Evento() 
                            {
                                EventoId = 1,
                                Local = "São Paulo",
                                DataEvento = DateTime.Now.AddDays(5),
                                Tema = "Angular 11 e .NET 5",
                                QtdPessoas = 250,
                                Lote = "Primeiro",
                                ImagemURL = "foto.png"
                            },
                            new Evento() 
                            {
                                EventoId = 2,
                                Local = "São Paulo",
                                DataEvento = DateTime.Now.AddDays(10),
                                Tema = "Angular 11 e .NET 5",
                                QtdPessoas = 250,
                                Lote = "Segundo",
                                ImagemURL = "foto.png"
                            }
                        };
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _evento.Where(x => x.EventoId == id);
        }

        [HttpPost]
        public String Post(int id)
        {
            return $"Exemplo de POST id = {id}";
        }

        [HttpPut]
        public String Put(int id)
        {
            return $"Exemplo de PUT id = {id}";
        }
    }
}
