using System.Collections.Generic;
using System.Linq;
using Dapper;
using TravelManager.Models;

namespace TravelManager.Repositories.Impl
{
    public class PacoteTuristicoRepository : IPacoteTuristicoRepository
    {
        public static class Queries
        {
            public const string CREATE = @"INSERT INTO db_travelmanager.pacote_turistico(
                                                  nome,
                                                  origem,
                                                  destino,
                                                  atrativos,
                                                  saida,
                                                  retorno,
                                                  cod_usuario_criacao
                                            )
                                            VALUES(
                                                   @Nome,
                                                   @Origem,
                                                   @Destino,
                                                   @Atrativos,
                                                   @Saida,
                                                   @Retorno,
                                                   @CodUsuarioCriacao
                                             );SELECT MAX(id_pacote_turistico) FROM db_travelmanager.pacote_turistico;";

            public const string UPDATE = @"UPDATE
                                                db_travelmanager.pacote_turistico
                                           SET
                                                nome = @Nome,
                                                origem = @Origem,
                                                destino = @Destino,
                                                atrativos = @Atrativos,
                                                saida = @Saida,
                                                retorno = @Retorno,
                                                cod_usuario_criacao = @CodUsuarioCriacao
                                                WHERE
                                                    id_pacote_turistico = @Id;";

            public const string DELETE = @"DELETE FROM db_travelmanager.pacote_turistico
                                            WHERE 
                                                 id_pacote_turistico = @Id;";
            public const string GET_ALL = @"SELECT
                                                id_pacote_turistico AS Id,
                                                nome AS Nome,
                                                origem AS Origem,
                                                destino AS Destino,
                                                atrativos AS Atrativos,
                                                saida AS Saida,
                                                retorno AS Retorno,
                                                cod_usuario_criacao AS CodUsuarioCriacao 
                                            FROM
                                                db_travelmanager.pacote_turistico ";
            public const string GET_BY_ID = GET_ALL + @"WHERE id_pacote_turistico= @Id";
        }


        private IConnectionProvider _connectionProvider;

        public PacoteTuristicoRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public int Create(PacoteTuristico pacoteTuristico)
        {
            var novoIdPacote = 0;
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                novoIdPacote = conn.Query<int>(Queries.CREATE, pacoteTuristico).FirstOrDefault();
            }

            return novoIdPacote;
        }

        public void Delete(int id)
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                conn.Execute(Queries.DELETE, new { Id = id });
            }
        }

        public List<PacoteTuristico> GetAll()
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                return conn.Query<PacoteTuristico>(Queries.GET_ALL).ToList();
            }
        }

        public PacoteTuristico GetById(int id)
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                return conn.Query<PacoteTuristico>(Queries.GET_BY_ID, new { Id = id }).FirstOrDefault();
            }
        }
        public void Update(PacoteTuristico pacoteTuristico)
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                conn.Execute(Queries.UPDATE, pacoteTuristico);
            }
        }
    }
}