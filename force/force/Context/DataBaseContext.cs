using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using force.Models;
using Microsoft.EntityFrameworkCore;

namespace force.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)   
        {
            
        }

        public DbSet<JugadorDto> JugadorDtos { get; set; }
        public DbSet<VR_SCORING>SCORINGs {get; set;}
        public DbSet<JugadotScoringDto>jugadotScoringDtos {get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Team> dbSetTeam { get; set; }      
    }
}