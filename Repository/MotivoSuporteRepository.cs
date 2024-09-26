using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MotivoSuporte.Data;
using MotivoSuporte.Entities;
using MotivoSuporte.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MotivoSuporte.Repository
{
    public class MotivoSuporteRepository : IMotivoSuporteRepository
    {
        private readonly Data.Context _context;

        public MotivoSuporteRepository(Data.Context context)
        {
            _context = context;
        }

        public async Task Add(Motivo_Suporte motivoSuporte)
        {
            _context.Motivos_Suporte.Add(motivoSuporte);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Motivo_Suporte>> GetByCnpj(decimal cnpj)
        {
            return await _context.Motivos_Suporte
                .Where(m => m.Num_CNPJ == cnpj)
                .ToListAsync();
        }
        public async Task Edit(Motivo_Suporte motivoSuporte)
        {
            _context.Motivos_Suporte.Update(motivoSuporte);
            await _context.SaveChangesAsync();
        }
        public async Task<Motivo_Suporte> GetById(int id)
        {
            return await _context.Motivos_Suporte
                .FirstOrDefaultAsync(ms => ms.Id == id);
        }

        public async Task Delete(int id)
        {
            var motivo_suporte = await _context.Motivos_Suporte.FindAsync(id);
            if(motivo_suporte != null)
            {
             _context.Motivos_Suporte.Remove(motivo_suporte);
                await _context.SaveChangesAsync();
            }
        }
    }
}