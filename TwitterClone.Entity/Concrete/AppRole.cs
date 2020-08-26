using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Abstract;
using Microsoft.AspNetCore.Identity;

namespace TwitterClone.Entity.Concrete
{
    public class AppRole : IdentityRole<int>, IEntity
    {
    }
}
