using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMAO.Domain.Model;
using TIMAO.Infrastructure;
using TIMAO.Domain;




namespace TIMAO.Infrastructure
{
    public class AdminRepository
    {
        
            public readonly Context _context;
            public Context UnitOfWork
            {
                get
                {
                    return _context;
                }
            }
            public AdminRepository(Context context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
       public async Task<List<Admin?>> GetAllAsync()
        {
            return await _context.Admins.OrderBy(a => a.NickName).ToListAsync();
            
        }

        public async Task AddAdmin(Admin admin)
        {
            _context.Add(admin);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAdmin(Guid id)
        {
            Admin? admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Admin?>GetByAsync(Guid id)
        {
            return await _context.Admins.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Admin?> GetByNickNameAsync(string nickname)
        {
            return await _context.Admins
                .Where(a => a.NickName == nickname)
                .FirstOrDefaultAsync();
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task UpdateAsync( Admin admin)
        {
           var existAdmin = GetByAsync(admin.Id).Result;
            if (existAdmin != null)

                _context.Entry(existAdmin).CurrentValues.SetValues(admin);
            await _context.SaveChangesAsync();
        }
        
    }
}
