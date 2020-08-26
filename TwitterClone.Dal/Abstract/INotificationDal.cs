using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {

        Task<List<Notification>> GetAllUnViewed(int id);

    }
}
