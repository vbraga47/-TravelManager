using System.Collections.Generic;
using TravelManager.Models;

namespace TravelManager.Repositories
{
    public interface IUsuarioRepository
    {
        int Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario GetById(int id);
        List<Usuario> GetAll();

    }
}