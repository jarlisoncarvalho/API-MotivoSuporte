using MotivoSuporte.Entities;

namespace MotivoSuporte.Repository.Interfaces
{
    public interface IMotivoSuporteRepository
    {
        Task Add(Motivo_Suporte motivoSuporte);
        Task<IEnumerable<Motivo_Suporte>> GetByCnpj(decimal cnpj);
        Task Edit(Motivo_Suporte motivoSuporte);
        Task<Motivo_Suporte> GetById(int id);
        Task Delete(int id);
    }
}
