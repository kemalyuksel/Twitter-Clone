using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class LikeManager : GenericManager<Like>, ILikeService
    {

        private readonly IGenericDal<Like> _genericDal;
        private readonly ILikeDal _likeDal;

        public LikeManager(IGenericDal<Like> genericDal, ILikeDal likeDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _likeDal = likeDal;
        }
    }
}
