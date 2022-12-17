using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMAO.Domain;
using TIMAO.Domain.Model;

namespace TIMAO.Infrastructure.Repository
{
    internal class ReaderRepository
    {
       
            private readonly Context _context;
            public Context UnitOfWork
            {
                get
                {
                    return _context;
                }
            }
            public ReaderRepository(Context context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

        public async Task<List<Reader?>> GetAllAsync()
        {
            return await _context.Readers.OrderBy(r => r.NickName).ToListAsync();
            ;
        }
        public async Task AddReader(Reader reader)
        {
            _context.Add(reader);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteReader(Guid id)
        {
            Reader? reader = await _context.Readers.FindAsync(id);
            if (reader != null)
            {
                _context.Remove(reader);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Reader?> GetByAsync(Guid id)
        {
            return await _context.Readers.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Reader?> GetByNickNameAsync(string nickname)
        {
            return await _context.Readers
                .Where(a => a.NickName == nickname)
                .FirstOrDefaultAsync();
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
