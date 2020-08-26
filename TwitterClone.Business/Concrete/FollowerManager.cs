using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class FollowerManager : GenericManager<Follower>, IFollowerService
    {

        private readonly IGenericDal<Follower> _genericDal;
        private readonly IFollowerDal _followerDal;

        public FollowerManager(IGenericDal<Follower> genericDal,
           IFollowerDal followerDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _followerDal = followerDal;
        }





    }
}
