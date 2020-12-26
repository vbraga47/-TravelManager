using System.Collections.Generic;
using System.Linq;
using Dapper;
using TravelManager.Models;

namespace TravelManager.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public static class Queries
        {
            public const string CREATE = @"INSERT INTO db_travelmanager.usuario(
                                                nome_completo,
                                                data_nascimento,
                                                login,
                                                senha,
                                                tipo
                                            )
                                            VALUES(
                                               @NomeCompleto,
                                               @DataNascimento,
                                               @Login,
                                               @Senha,
                                               @Tipo
                                            );SELECT MAX(id_usuario) FROM db_travelmanager.usuario;";

            public const string UPDATE = @" UPDATE 
                                                db_travelmanager.usuario
                                            SET 
                                                nome_completo = @NomeCompleto,
                                                data_nascimento = @DataNascimento,
                                                login = @Login,
                                                senha = @Senha,
                                                tipo = @Tipo,
                                            WHERE
                                                id_usuario = @Id;";

            public const string DELETE = @"DELETE FROM db_travelmanager.usuario WHERE id_usuario = @Id;";

            public const string GET_ALL = @"SELECT
                                                id_usuario AS Id,
                                                nome_completo AS NomeCompleto,
                                                data_nascimento AS DataNascimento,
                                                login AS Login,
                                                senha AS Senha,
                                                tipo AS Tipo
                                           FROM 
                                                db_travelmanager.usuario ";

            public const string GET_BY_ID = GET_ALL + @"WHERE id_usuario = @Id";

        }


        private IConnectionProvider _connectionProvider;

        public UsuarioRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public int Create(Usuario usuario)
        {
            var novoIdUsuario = 0;
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                novoIdUsuario = conn.Query<int>(Queries.CREATE, usuario).FirstOrDefault();
            }

            return novoIdUsuario;
        }

        public void Delete(int id)
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                conn.Execute(Queries.DELETE, new { Id = id });
            }
        }

        public List<Usuario> GetAll()
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                return conn.Query<Usuario>(Queries.GET_ALL).ToList();
            }
        }

        public Usuario GetById(int id)
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                return conn.Query<Usuario>(Queries.GET_BY_ID, new { Id = id }).FirstOrDefault();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var conn = _connectionProvider.GetConnection())
            {
                conn.Open();
                conn.Execute(Queries.UPDATE, usuario);
            }
        }
    }
}