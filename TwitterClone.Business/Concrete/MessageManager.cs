using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {

        private readonly IGenericDal<Message> _genericDal;
        private readonly IMessageDal _messageDal;

        public MessageManager(IGenericDal<Message> genericDal,
           IMessageDal messageDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _messageDal = messageDal;
        }

        public async Task AddMessage(Message model, int activeUserId, int secondUserId)
        {
            await _messageDal.AddMessage(model,activeUserId,secondUserId);
        }

        public async Task<List<Message>> GetOneToOneMessages(int activeUserId, int secondUserId)
        {
            return await _messageDal.GetOneToOneMessages(activeUserId, secondUserId);
        }
    }
}
