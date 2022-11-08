using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modulo_API.Entities;

namespace Modulo_API.Context
{
    public class AgendaContext : DbContext
    {   // construtor especial para passar a conexão com o banco de dados
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) 
        {

        }
        // uma entidade (classe no programa e tabela no DB)
        public DbSet<Contato> Contatos {get; set; } 
    }
}