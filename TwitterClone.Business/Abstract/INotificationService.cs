using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        Task<List<Notification>> GetAllUnViewed(int id);


    }
}
