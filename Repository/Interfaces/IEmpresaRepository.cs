using MotivoSuporte.Entities;

namespace MotivoSuporte.Repository.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<Empresa> Get(int idfEmpresa);
        Task<List<Empresa>> GetAll();
        Task<Empresa> GetByCnpj(decimal cnpj);
   
    }
}
