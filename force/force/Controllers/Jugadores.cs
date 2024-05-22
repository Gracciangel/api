using force.Context;
using force.Interfaces;
using force.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace force.Controllers
{
    [ApiController]
    [Route("Bioforce/")]
    public class VR_USUARIO : ControllerBase
    {
        private readonly IJugador _context;


        public VR_USUARIO(IJugador context)
        {
            _context = context;


        }

        [HttpGet("jugadores")]
        public async Task<IActionResult> GetJugadores()
        {
            return Ok(await _context.GetJugadores());
        }

        [HttpGet("jugadores/{Nickname}")]
        public async Task<IActionResult> GetJugador(string Nickname)
        {
            return Ok(await _context.GetJugador(Nickname));
        }

        [HttpGet("partida")]
        public async Task<IActionResult> GetPartida(int partida){
            return Ok(await _context.GetPartida(partida)) ;
        }   

        [HttpGet("partidaID")]
        public async Task<IActionResult> GetLastPartdia(){
            return Ok(await _context.GetLastPartdia()) ;
        }

        [HttpGet("state")]
            public async Task<IActionResult> GetStateTeam()
            {
                try
                {
                    var state = await _context.GetStateTeam();
                    return Ok(state);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return StatusCode(500, "Internal server error");
                }
            }
        [HttpGet("players-teams")]
        public async Task<IActionResult>GetPlayers() {
            return Ok(await _context.GetPlayers()) ;
        }
        
         [HttpPost("jugadores/new")]

        public async Task<IActionResult> AddJugador([FromBody] JugadorDto jugador)
        {

            if (string.IsNullOrEmpty(jugador.Nickname) && string.IsNullOrEmpty(jugador.Documento) && string.IsNullOrEmpty(jugador.Nombre) && string.IsNullOrEmpty(jugador.Apellido) && string.IsNullOrEmpty(jugador.Mail) && string.IsNullOrEmpty(jugador.Colegio) && string.IsNullOrEmpty(jugador.Facebook) && string.IsNullOrEmpty(jugador.Instagram))
            {
                return BadRequest("Jugador no agregado");
            }
            else
            {

                return Ok(await _context.AddJugador(jugador.Nickname, jugador.Documento, jugador.Nombre, jugador.Apellido, jugador.Edad, jugador.Mail, jugador.Colegio, jugador.Facebook, jugador.Instagram));
            }
        }
        
        // post nuevo jugador desde unity 

        [HttpPost("scoring/new")]
        public async Task<IActionResult> AddUnity([FromBody] JugadotScoringDto jugador)
        {
            return Ok(await _context.AddUnity(jugador.Scoring, jugador.Nickname));
        }
        
        [HttpPost("partida")]
        public async Task<IActionResult> PartidaNew()
        {
            return Ok(await _context.PartidaNew());
        }

        [HttpPut("partida/team/{team}")]
        public async Task<IActionResult> AddPlayersToTeam( int partida , string team, [FromBody] Team jugador)
        {
            
            return Ok(await _context.AddPlayersToTeam(partida, jugador));
        }

        [HttpPut("jugadores/edit/{Nickname}")]

        public async Task<IActionResult> UpdateJugador([FromBody] JugadorDto jugador)
        {
            if (string.IsNullOrEmpty(jugador.Nickname))
            {
                Console.WriteLine("jugador nulo o vacio");
                return BadRequest("Error");
            }
            else
            {

                return Ok(await _context.UpdateJugador(jugador));
            }

        }

        [HttpPut("team/state")]
        public async Task<IActionResult> ChangeStateTeam(int partida, [FromBody] Team team){
            return Ok(await _context.ChangeStateTeam(partida, team)) ;
        }
        [HttpPut("partida/state")]
        public async Task<IActionResult> ChangeStatePartida(int partida , int state){
            
            return Ok(await _context.ChangeStatePartida(partida, state)) ;
        }
       
        [HttpDelete("jugadores/delete")]

        public async Task<IActionResult> DeleteJugador(string Nickname)
        {

            return Ok(await _context.DeleteJugador(Nickname));
        }

        [HttpDelete("drop")]
        public async Task<IActionResult> DeleteTeams(){
            return Ok(await _context.DeleteTeams()) ;
            
        }
      
}       
    }


