using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Abstract
{
    public interface ITweetService : IGenericService<Tweet>
    {

        //Task<List<Tweet>> GetTweetsWithUser(string userName);
        //Task<List<Tweet>> GetAllTweetsWithUsers();

        Task<List<Tweet>> GetAllWithUser<TKey>(Expression<Func<Tweet, TKey>> keySelector);
        Task<List<Tweet>> GetAllWithUser(string userName);
        Task<List<Tweet>> GetAllWithUser<TKey>(Expression<Func<Tweet, bool>> filter, Expression<Func<Tweet, TKey>> keySelector);

    }
}
