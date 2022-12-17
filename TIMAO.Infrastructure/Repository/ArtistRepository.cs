using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMAO.Domain;
using TIMAO.Domain.Model;
using TIMAO.Infrastructure;

namespace TIMAO.Infrastructure.Repository
{
    public class ArtistRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ArtistRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Artist?>> GetAllAsync()
        {
            return await _context.Artists.OrderBy(a => a.NickName).ToListAsync();
            ;
        }
        public async Task AddArtist(Artist artist)
        {
            _context.Add(artist);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteArtist(Guid id)
        {
            Artist? artist = await _context.Artists.FindAsync(id);
            if(artist != null)
            {
                _context.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Artist?> GetByAsync(Guid id)
        {
            return await _context.Artists.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Artist?> GetByNickNameAsync(string nickname)
        {
            return await _context.Artists
                .Where(a => a.NickName == nickname)
                .FirstOrDefaultAsync();
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }
    }
   
}
