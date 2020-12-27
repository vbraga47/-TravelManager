using System.Collections.Generic;
using TravelManager.Models;

namespace TravelManager.Services
{
    public interface ICadastroPacoteTuristicoServices
    {
        PacoteTuristico BuscarPorId(int idPacoteTuristico);
        int CriarPacoteTuristico(PacoteTuristico pacoteTuristico);
        void EditarPacoteTuristico(PacoteTuristico pacoteTuristico);
        void ExcluirPacoteTuristico(int idPacoteTuristico);
        List<PacoteTuristico> ListarTodos();
    }
}
