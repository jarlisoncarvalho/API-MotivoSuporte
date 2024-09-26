using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MotivoSuporte.Data;
using MotivoSuporte.Entities;
using MotivoSuporte.Repository.Interfaces;

namespace MotivoSuporte.Repository
{
    public class MotivoRepository : IMotivosRepository
    {
        private readonly Data.Context _context;

        public MotivoRepository(Data.Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Motivos>> GetAll()
        {
            return await _context.Motivos.ToListAsync();
        }

        public async Task<Motivos> GetById(int id)
        {
            return await _context.Motivos.FindAsync(id);
        }

        public async Task Add(Motivos motivo)
        {
            await _context.Motivos.AddAsync(motivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Motivos> Update(int id, Motivos EditMotivo)
        {
            var motivos = await _context.Motivos.FindAsync(id);
            if (motivos == null)
            {
                throw new Exception("Motivo não encontrado");
            }

         
            motivos.Motivo = EditMotivo.Motivo;

            _context.Motivos.Update(motivos);
            await _context.SaveChangesAsync();

         
            return motivos;
        }

        public async Task Delete(int id)
        {
            var motivo = await _context.Motivos.FindAsync(id);
            if (motivo != null)
            {
                _context.Motivos.Remove(motivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}