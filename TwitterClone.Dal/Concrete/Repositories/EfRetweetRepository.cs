﻿using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Dal.Abstract;
using TwitterClone.Dal.Concrete.Context;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Repositories
{
    public class EfRetweetRepository : EfGenericRepository<Retweet>,IRetweetDal
    {

        public EfRetweetRepository(TwitterContext context) : base(context)
        {

        }

    }
}
