using System.Collections.Generic;
using TravelManager.Models;

namespace TravelManager.Services
{
    public interface ICadastroUsuarioServices
    {
        Usuario BuscarPorId(int idUsuario);
        int CriarUsuario(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        void ExcluirUsuario(int idUsuario);
        List<Usuario> ListarTodos();

    }
}
