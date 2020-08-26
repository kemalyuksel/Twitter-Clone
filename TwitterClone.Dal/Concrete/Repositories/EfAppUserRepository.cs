using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Dal.Abstract;
using TwitterClone.Dal.Concrete.Context;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>,IAppUserDal
    {

        private readonly TwitterContext _context;

        public EfAppUserRepository(TwitterContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetOtherUsers(int id)
        {


            return await _context.Users.Where(x => x.Id != id).Take(5).ToListAsync();
        }
    }
}
