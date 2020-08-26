using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class TweetManager : GenericManager<Tweet>, ITweetService
    {

        private readonly IGenericDal<Tweet> _genericDal;
        private readonly ITweetDal _tweetDal;

        public TweetManager(IGenericDal<Tweet> genericDal, ITweetDal tweetDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _tweetDal = tweetDal;
        }

        public async Task<List<Tweet>> GetAllWithUser<TKey>(Expression<Func<Tweet, TKey>> keySelector)
        {
            return await _tweetDal.GetAllWithUser(keySelector);
        }

        public async Task<List<Tweet>> GetAllWithUser(string userName)
        {
            return await _tweetDal.GetAllWithUser(userName);
        }

        public async Task<List<Tweet>> GetAllWithUser<TKey>(Expression<Func<Tweet, bool>> filter, Expression<Func<Tweet, TKey>> keySelector)
        {
            return await _tweetDal.GetAllWithUser(filter,keySelector);
        }
    }
}
