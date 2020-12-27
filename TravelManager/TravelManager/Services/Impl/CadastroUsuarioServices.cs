using System.Collections.Generic;
using TravelManager.Models;
using TravelManager.Repositories;

namespace TravelManager.Services.Impl
{
    public class CadastroUsuarioServices : ICadastroUsuarioServices
    {
        private IUsuarioRepository _usuarioRepository;
        public CadastroUsuarioServices(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            var usuario = _usuarioRepository.GetById(idUsuario);
            
            return usuario;
        }

        public int CriarUsuario(Usuario usuario)
        {
            var novoId = _usuarioRepository.Create(usuario);
            return novoId;
        }

        public void EditarUsuario(Usuario usuario)
        {
            var usuarioAtual = _usuarioRepository.GetById(usuario.Id);
            usuario.Senha = string.IsNullOrEmpty(usuario.Senha) ? usuarioAtual.Senha : usuario.Senha;
            
            _usuarioRepository.Update(usuario);
        }

        public void ExcluirUsuario(int idUsuario)
        {
            _usuarioRepository.Delete(idUsuario);
        }

        public List<Usuario> ListarTodos()
        {
            List<Usuario> usuarios = _usuarioRepository.GetAll();
            return usuarios;
        }
    }
}
