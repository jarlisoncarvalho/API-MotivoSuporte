using MotivoSuporte.Entities;

namespace MotivoSuporte.Repository.Interfaces
{
    public interface IMotivosRepository
    {
        Task<IEnumerable<Motivos>> GetAll();
        Task<Motivos> GetById(int id);
        Task Add(Motivos motivo);
        Task<Motivos> Update(int id, Motivos EditMotivo);
        Task Delete(int id);
    }
}
