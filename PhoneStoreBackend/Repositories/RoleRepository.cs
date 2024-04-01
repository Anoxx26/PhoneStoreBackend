using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Data;
using PhoneStoreBackend.Models;

namespace PhoneStoreBackend.Repositories
{
    public class RoleRepository
    {
        private ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
        }
    }
}
