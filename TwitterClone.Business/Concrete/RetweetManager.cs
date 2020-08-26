using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class RetweetManager : GenericManager<Retweet>, IRetweetService
    {

        private readonly IGenericDal<Retweet> _genericDal;
        private readonly IRetweetDal _retweetDal;


        public RetweetManager(IGenericDal<Retweet> genericDal, IRetweetDal retweetDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _retweetDal = retweetDal;

        }

    }
}
