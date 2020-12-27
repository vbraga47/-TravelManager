using System.Collections.Generic;
using TravelManager.Models;

namespace TravelManager.Repositories
{
    public interface IPacoteTuristicoRepository
    {
        int Create(PacoteTuristico pacoteTuristico);
        void Update(PacoteTuristico pacoteTuristico);
        void Delete(int id);
        PacoteTuristico GetById(int id);
        List<PacoteTuristico> GetAll();
    }
}