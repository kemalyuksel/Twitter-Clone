using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class NotificationManager : GenericManager<Notification>, INotificationService
    {

        private readonly IGenericDal<Notification> _genericDal;
        private readonly INotificationDal _notificationDal;

        public NotificationManager(IGenericDal<Notification> genericDal,
           INotificationDal notificationDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _notificationDal = notificationDal;
        }

        public async Task<List<Notification>> GetAllUnViewed(int id)
        {
            return await _notificationDal.GetAllUnViewed(id);
        }
    }
}
