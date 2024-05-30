using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using force.Models;
using Microsoft.AspNetCore.Mvc;

namespace force.Interfaces
{
    public interface IJugador
    {
      //obtener todos 
      Task<IEnumerable<JugadotScoringDto>>GetJugadores() ;
      
      //obtener un jugador
      Task<JugadotScoringDto>GetJugador(string Nickname) ;
        //   //actualizar datos de usuario
      Task<int>UpdateJugador([FromBody]JugadorDto jugador);

        // //   //agregar un usuario nuevo 
      Task<int>AddJugador(string Nickname, string Documento, string Nombre, string Apellido, int Edad , string Mail, string Colegio, string Facebook , string Instagram) ;

        // //   //eliminar un usuario 
      Task<int>DeleteJugador(string Nickname); 
      // agregar un usuario desde unity 
      Task<int>AddUnity(int Scoring, string Nickname) ;
      //crear nueva partida
      Task<int>PartidaNew() ;
      
      Task<int> AddPlayersToTeam(int partida, [FromBody] Team jugador) ;
      Task<int>DeleteTeams(); 
   
      Task<int> GetPartida(int partida) ;
      Task<int> GetPartidaState(int partida) ;
      Task<int>ChangeStateTeam(int partida, string team ); 
      Task<int> ChangeStatePartida(int partida, int state) ; 

      Task<IEnumerable<Team>> GetStateTeam(); 

      Task<IEnumerable<Team>> GetPlayers() ;

      Task<IEnumerable<int>> GetLastPartdia() ; 
    }
}