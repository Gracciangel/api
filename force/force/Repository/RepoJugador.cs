
using force.Interfaces;
using force.Models;
using MySql.Data.MySqlClient;
using Dapper;
using force.Validations;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using force.Context;

using Microsoft.EntityFrameworkCore;
using System.Transactions;
namespace force.Repository
{

    public class RepoJugador : IJugador
    {
        Validation validation = new Validation();
        private readonly SqlConfiguration _connectionString;

        private readonly DataBaseContext _context;
        public RepoJugador(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        //obtener todos los jugadores -----------------------------------------------------------
        public async Task<IEnumerable<JugadotScoringDto>> GetJugadores()
        {

            using (var connection = GetConnection())
            {
                var sql = @"SELECT * FROM VR_DATOS_USUARIOS INNER JOIN VR_SCORING_USUARIO ON VR_DATOS_USUARIOS.NICKNAME = VR_SCORING_USUARIO.NICKNAME WHERE VR_DATOS_USUARIOS.NICKNAME = VR_SCORING_USUARIO.NICKNAME
                 ORDER BY VR_SCORING_USUARIO.SCORING DESC";
                return await connection.QueryAsync<JugadotScoringDto>(sql, new { });
            }
        }

        //     //obtener un solo jugador ---------------------------------------------------------

        public async Task<JugadotScoringDto> GetJugador(string NICKNAME)
        {
            using (var connection = GetConnection())
            {

                var sql = @"SELECT * FROM VR_DATOS_USUARIOS INNER JOIN VR_SCORING_USUARIO ON VR_DATOS_USUARIOS.NICKNAME = VR_SCORING_USUARIO.NICKNAME WHERE VR_DATOS_USUARIOS.NICKNAME = @NICKNAME;
                    ";

                return await connection.QueryFirstOrDefaultAsync<JugadotScoringDto>(sql, new { NICKNAME = NICKNAME });

            }
        }


        //     //actualizar jugador ---------------------------------------------------------------

        public async Task<int> UpdateJugador([FromBody] JugadorDto jugador)
        {

            using (var connection = GetConnection())
            {
                var sqlUpdateUsuario = @"
                UPDATE VR_DATOS_USUARIOS 
                SET DOCUMENTO = @DOCUMENTO, 
                    NOMBRE = @NOMBRE, 
                    APELLIDO = @APELLIDO, 
                    EDAD = @EDAD, 
                    MAIL = @MAIL, 
                    COLEGIO = @COLEGIO, 
                    FACEBOOK = @FACEBOOK, 
                    INSTAGRAM = @INSTAGRAM 
                WHERE NICKNAME = @NICKNAME;
            ";
                if (validation.ValidateDoc(jugador.Documento) &&
                        validation.ValidateName(jugador.Nombre, 4, 8) &&
                        validation.ValidateName(jugador.Apellido, 3, 10) &&
                        validation.ValidateEdad(jugador.Edad)
                        )
                {
                    try
                    {
                        await connection.ExecuteAsync(sqlUpdateUsuario, new
                        {
                            jugador.Nickname,
                            jugador.Documento,
                            jugador.Nombre,
                            jugador.Apellido,
                            jugador.Edad,
                            jugador.Mail,
                            jugador.Colegio,
                            jugador.Facebook,
                            jugador.Instagram

                        });
                        Console.WriteLine($"Jugador {jugador.Nickname} actualizado correctamente");
                        return 1;




                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR AL ACTUALIZAR UN JUGADOR: {ex.Message}");
                        return 0;
                    }

                }
                else
                {
                    Console.WriteLine($" Error Al acutalizar el jugador {jugador.Nickname}");
                    return 0;

                }


            }

        }

        //     //Agregar jugador -------------------------------------------------------------
        public async Task<int> AddJugador(string NICKNAME, string DOCUMENTO, string NOMBRE, string APELLIDO, int EDAD, string MAIL, string COLEGIO, string FACEBOOK, string INSTAGRAM)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sql = @" INSERT INTO VR_DATOS_USUARIOS (NICKNAME, DOCUMENTO, NOMBRE, APELLIDO, EDAD, MAIL, COLEGIO,FACEBOOK, INSTAGRAM) VALUES(@NICKNAME, @DOCUMENTO, @NOMBRE, @APELLIDO, @EDAD, @MAIL, @COLEGIO, @FACEBOOK, @INSTAGRAM) ";


                        if (validation.ValidateNick(NICKNAME))
                            NICKNAME = NICKNAME;
                        if (validation.ValidateDoc(DOCUMENTO))
                            DOCUMENTO = DOCUMENTO;
                        if (validation.ValidateName(NOMBRE, 4, 8))
                            NOMBRE = NOMBRE;
                        if (validation.ValidateName(APELLIDO, 3, 10))
                            APELLIDO = APELLIDO;
                        if (validation.ValidateEdad(EDAD))
                            EDAD = EDAD;
                        await connection.ExecuteAsync(sql, new
                        {


                            NICKNAME = NICKNAME,
                            DOCUMENTO = DOCUMENTO,
                            NOMBRE = NOMBRE,
                            APELLIDO = APELLIDO,
                            EDAD = EDAD,
                            MAIL = MAIL,
                            COLEGIO = COLEGIO,
                            FACEBOOK = FACEBOOK,
                            INSTAGRAM = INSTAGRAM
                        });
                        var sqlScoring = @"INSERT INTO VR_SCORING_USUARIO(SCORING , NICKNAME)
                                            VALUES( 0 , @NICKNAME)";
                        await connection.ExecuteAsync(sqlScoring, new { NICKNAME }, transaction);

                        transaction.Commit();
                        return 1;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error al agregar jugador: {ex.Message}");

                        return 0;
                    }
                }
            }
        }

        public async Task<int> DeleteJugador(string Nickname)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sqlDelete = @"
                    DELETE FROM VR_SCORING_USUARIO WHERE NICKNAME = @NICKNAME;
                    DELETE FROM VR_DATOS_USUARIOS WHERE NICKNAME = @NICKNAME;
                ";
                        await connection.ExecuteAsync(sqlDelete, new { NICKNAME = Nickname }, transaction);
                        transaction.Commit();
                        return 1;
                    }
                    catch (MySqlException ex)
                    {

                        Console.WriteLine($"Error al eliminar jugador: {ex.Message}");
                        transaction.Rollback();
                        return 0;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Error al eliminar jugador: {ex.Message}");
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        public async Task<int> AddUnity(int Scoring, string Nickname)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sql = @" INSERT INTO VR_DATOS_USUARIOS (NICKNAME, DOCUMENTO, NOMBRE, APELLIDO, EDAD, MAIL, COLEGIO,FACEBOOK, INSTAGRAM) VALUES(@NICKNAME, @DOCUMENTO, @NOMBRE, @APELLIDO, @EDAD, @MAIL, @COLEGIO, @FACEBOOK, @INSTAGRAM) ";
                        await connection.ExecuteAsync(sql, new
                        {


                            NICKNAME = Nickname,
                            DOCUMENTO = " ",
                            NOMBRE = " ",
                            APELLIDO = " ",
                            EDAD = 0,
                            MAIL = " ",
                            COLEGIO = " ",
                            FACEBOOK = " ",
                            INSTAGRAM = " "
                        });
                        var sqlScoring = @"INSERT INTO VR_SCORING_USUARIO(SCORING , NICKNAME)
                                            VALUES( 0 , @NICKNAME)";
                        await connection.ExecuteAsync(sqlScoring, new { Nickname }, transaction);

                        transaction.Commit();
                        return 1;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error al agregar jugador: {ex.Message}");

                        return 0;
                    }
                }
            }
        }
        //iniciar partida nueva
        public async Task<int> PartidaNew()
        {

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        var insertID_VR_partida = $@"INSERT INTO VR_PARTIDA (STATE) VALUES (@STATE);
                       SELECT LAST_INSERT_ID();";
                        var partidaId = await connection.QueryFirstOrDefaultAsync<int>(insertID_VR_partida, new { STATE = 1 });


                        var teams = new string[] { "BLUE", "GREEN", "ORANGE", "PINK", "RED", "YELLOW" };

                        foreach (var team in teams)
                        {
                            var insertTeamData = $@"INSERT INTO TEAM_{team}
                                            (ID , COMPLETE, NICK_1, NICK_2, NICK_3, NICK_4, NICK_5, PARTIDA_ID, TEAM) 
                                            VALUES (NULL,  @COMPLETE, '', '', '', '', '', @PARTIDA_ID, @TEAM);";
                            await connection.ExecuteAsync(insertTeamData, new { COMPLETE = false, PARTIDA_ID = partidaId , TEAM=team});
                        }


                        transaction.Commit();
                        return partidaId; // Devolver el ID de la partida creada
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error al crear la partida: {ex.Message}");
                        return 0;
                    }
                }
            }
        }

        public async Task<int> AddPlayersToTeam(int partida, [FromBody] Team jugador)
        {
            using (var connection = GetConnection())
            {

                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var getpartidaId = await GetPartida(partida);
                        var sql = $@"UPDATE TEAM_{jugador.TEAM}
                             SET NICK_1 = @NICK_1, NICK_2 = @NICK_2, NICK_3 = @NICK_3, NICK_4 = @NICK_4, NICK_5 = @NICK_5
                             WHERE PARTIDA_ID = {getpartidaId};";
                        await connection.ExecuteAsync(sql, new
                        {
                            NICK_1 = jugador.NICK_1,
                            NICK_2 = jugador.NICK_2,
                            NICK_3 = jugador.NICK_3,
                            NICK_4 = jugador.NICK_4,
                            NICK_5 = jugador.NICK_5,
                            PARTIDA_ID = getpartidaId
                        });
                        Console.WriteLine($"{jugador.NICK_5} {jugador.TEAM}");
                        transaction.Commit();
                        return 1;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("los nick no pudieron ser actualzados \n" + ex.Message);
                        return 0;
                    }
                }
            }
        }

        public async Task<int> DeleteTeams()
        {
            using (var connection = GetConnection())
            {
                var teams = new string[6] { "RED", "GREEN", "BLUE", "YELLOW", "ORANGE", "PINK" };

                try
                {
                    await connection.OpenAsync();

                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (var team in teams)
                        {
                            var sqlDelete = $@"
                        DROP TABLE IF EXISTS TEAM_{team}; 
                    ";

                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = sqlDelete;
                                await command.ExecuteNonQueryAsync();
                            }
                        }

                        transaction.Commit();
                        return 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return 0;
                }
            }
        }

        public async Task<int> GetPartida(int partida)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var getPartidaSQL = @"SELECT ID_PARTIDA FROM VR_PARTIDA WHERE ID_PARTIDA = @partida";
                        var result = await connection.QueryFirstOrDefaultAsync<int>(getPartidaSQL, new { partida });
                        transaction.Commit();

                        if (result != default(int))
                        {
                            return result;
                        }
                        else
                        {
                            Console.WriteLine("No se encontró la partida.");
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la partida {ex.Message}");
                return 0;
            }
        }

        public async Task<int> ChangeStateTeam(int partida, [FromBody] Team team)
        {
            using (var connection = GetConnection())
            {

                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var partidaId = await GetPartida(partida);
                        var sql = $@"UPDATE TEAM_{team.TEAM}
                                SET COMPLETE = TRUE 
                             WHERE PARTIDA_ID = {partidaId};";
                        await connection.ExecuteAsync(sql, new
                        {
                            team.TEAM,
                            team.COMPLETE,
                            team.NICK_1,
                            team.NICK_2,
                            team.NICK_3,
                            team.NICK_4,
                            team.NICK_5,
                            PARTIDA_ID = partidaId
                        });

                        transaction.Commit();
                        return 1;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("los nick no pudieron ser actualzados \n" + ex.Message);
                        return 0;
                    }
                }
            }
        }
       public async Task<int> ChangeStatePartida(int partida, int state)
{
    try
    {
        using (var connection = GetConnection())
        {
            await connection.OpenAsync();
            Console.WriteLine("Database connection opened.");

            using (var transaction = connection.BeginTransaction())
            {
                var teams = new string[] { "RED", "GREEN", "BLUE", "YELLOW", "ORANGE", "PINK" };

                try
                {
                    foreach (var team in teams)
                    {
                
                        var changeSQL = $@"
                        UPDATE VR_PARTIDA
                        JOIN TEAM_{team}
                        ON TEAM_{team}.PARTIDA_ID = VR_PARTIDA.ID_PARTIDA
                        SET STATE = @STATE
                        WHERE TEAM_{team}.COMPLETE = TRUE AND VR_PARTIDA.ID_PARTIDA = @PARTIDA;";

                        await connection.ExecuteAsync(changeSQL, new
                        {
                            PARTIDA = partida,
                            STATE = state
                        }, transaction: transaction);

                        Console.WriteLine($"State updated for team {team}.");
                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return 1;
                }
                
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"General Error: {ex.Message}");
                    return 0;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Connection error: {ex.Message}");
        return 0;
    }
}

        public async Task<IEnumerable<Team>> GetStateTeam()
{
    var response = new List<Team>();

    try
    {
        using (var connection = GetConnection())
        {
            var teams = new string[] { "RED", "YELLOW", "GREEN", "PINK", "ORANGE", "BLUE" };
            foreach (var team in teams)
            {
                var stateListQuery = $@"
                    SELECT COMPLETE FROM TEAM_{team}
                    
                ";

                var teamState = await connection.QueryAsync<bool>(stateListQuery);
                foreach (var complete in teamState)
                {
                    response.Add(new Team { TEAM = team, COMPLETE = complete });
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw;
    }

    return response;
}

        public async Task<IEnumerable<Team>> GetPlayers()
{
    using (var connection = GetConnection())
    {
        var teams = new string[] { "RED", "YELLOW", "BLUE", "ORANGE", "PINK", "GREEN" };
        var result = new List<Team>();

        foreach (var team in teams)
        {
            var sql = $@"SELECT * FROM TEAM_{team}";
            var players = await connection.QueryAsync<Team>(sql, new{
                
            });
            result.AddRange(players);
        }

        return result;
    }
}

        public async Task<IEnumerable<int>> GetLastPartdia()
        {
              using(var connection = GetConnection())
    {
        try
        {
            await connection.OpenAsync();
            using(var transaction = connection.BeginTransaction())
            {
                var getLastIdSql = @"SELECT ID_PARTIDA FROM VR_PARTIDA 
                ;
                "; // Asegúrate de que este SQL selecciona la columna correcta
                var ids = await connection.QueryAsync<int>(getLastIdSql, new{});
                transaction.Commit();
                return ids ;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new int[0];
        }
    }
        }
    }
}






