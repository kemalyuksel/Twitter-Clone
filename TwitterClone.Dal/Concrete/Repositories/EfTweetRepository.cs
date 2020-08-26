using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Dal.Abstract;
using TwitterClone.Dal.Concrete.Context;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Repositories
{
    public class EfTweetRepository : EfGenericRepository<Tweet>,ITweetDal
    {

        private readonly TwitterContext _context;

        public EfTweetRepository(TwitterContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<Tweet>> GetTweetsWithUser(string userName)
        //{
        //    return await _context.Tweets.Include(x => x.AppUser).Where(x => x.AppUser.UserName == userName).OrderByDescending(x => x.PostedTime).ToListAsync();
        //}

        //public async Task<List<Tweet>> GetAllTweetsWithUsers()
        //{
        //    return await _context.Tweets.Include(x => x.AppUser).OrderByDescending(x => x.PostedTime).ToListAsync();
        //}

        public async Task<List<Tweet>> GetAllWithUser(string userName)
        {
            return await _context.Tweets.Include(x => x.AppUser).Where(x => x.AppUser.UserName == userName).OrderByDescending(x => x.PostedTime).ToListAsync();
        }

        public async Task<List<Tweet>> GetAllWithUser<TKey>(Expression<Func<Tweet, bool>> filter, Expression<Func<Tweet, TKey>> keySelector)
        {
            return await _context.Tweets.Include(x => x.AppUser).Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<Tweet>> GetAllWithUser<TKey>(Expression<Func<Tweet, TKey>> keySelector)
        {
            return await _context.Tweets.Include(x => x.AppUser).OrderByDescending(keySelector).ToListAsync();
        }
    }
}
