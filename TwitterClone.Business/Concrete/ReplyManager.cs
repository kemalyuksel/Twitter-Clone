using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class ReplyManager : GenericManager<Reply>, IReplyService
    {

        private readonly IGenericDal<Reply> _genericDal;
        private readonly IReplyDal _replyDal;

        public ReplyManager(IGenericDal<Reply> genericDal, IReplyDal replyDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _replyDal = replyDal;
        }

    }
}
