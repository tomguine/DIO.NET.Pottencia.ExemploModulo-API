using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // importante adicionar esses using's
using Modulo_API.Context;
using Modulo_API.Entities;

namespace Modulo_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContatoController : ControllerBase
    {

        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost] // Método para criar um contato
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges(); 
           return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato);
           // return Ok(contato);
        }

        [HttpGet("{id}")] // Método para buscar um contato 'get'
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null) // retorna NotFound caso não encontre o id
                return NotFound();

            return Ok(contato);
        }

        [HttpPut("{id}")] 
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);  // Só pra diferenciar que o contato vem do banco, não da requisição

            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();  // para salvar as alterações realizadas

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges(); // para salvar as alterações realizadas

            return NoContent(); // retorno 204 (família de código de sucesso), 204 significa que teve sucesso mas não retornou nada
        }
    }
}