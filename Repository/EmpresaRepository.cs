using Microsoft.EntityFrameworkCore;
using MotivoSuporte.Data;
using MotivoSuporte.Entities;
using MotivoSuporte.Repository.Interfaces;

namespace MotivoSuporte.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly Data.Context _context;

        public EmpresaRepository(Data.Context context)
        {
            _context = context;
        }
        public async Task<Empresa> Get(int idfEmpresa)
        {
            return await _context.Empresa
             .FirstOrDefaultAsync(e => e.Idf_Empresa == idfEmpresa);
        }
        public async Task<List<Empresa>> GetAll()
        {
            return await _context.Empresa
            .Take(100)
            .ToListAsync();
        }
        public async Task<Empresa> GetByCnpj(decimal cnpj)
        {
            return await _context.Empresa
        .FirstOrDefaultAsync(e => e.Num_CNPJ == cnpj);
        }
    }
}
