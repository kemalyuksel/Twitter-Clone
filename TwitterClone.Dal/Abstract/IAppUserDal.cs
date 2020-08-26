using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {

        Task<List<AppUser>> GetOtherUsers(int id);

    }
}
