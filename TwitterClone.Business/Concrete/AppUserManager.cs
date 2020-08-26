using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Abstract;
using TwitterClone.Dal.Abstract;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {

        private readonly IGenericDal<AppUser> _genericDal;
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal,
           IAppUserDal appUserDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _appUserDal = appUserDal;
        }

        public async Task<List<AppUser>> GetOtherUsers(int id)
        {
            return await _appUserDal.GetOtherUsers(id);
        }
    }
}
