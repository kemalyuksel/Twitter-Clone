using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        Task<List<Message>> GetOneToOneMessages(int activeUserId, int secondUserId);
        Task AddMessage(Message model, int activeUserId, int secondUserId);
    }
}
