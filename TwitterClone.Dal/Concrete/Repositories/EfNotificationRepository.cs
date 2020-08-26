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
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        private readonly TwitterContext _context;

        public EfNotificationRepository(TwitterContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllUnViewed(int id)
        {

            return await _context.Notifications.Where(x => x.AppUserId == id && x.Status == false).ToListAsync();

        }



    }
}
