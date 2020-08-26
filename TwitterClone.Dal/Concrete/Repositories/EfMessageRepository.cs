using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Dal.Abstract;
using TwitterClone.Dal.Concrete.Context;
using TwitterClone.Dto.DTOs.MessageDtos;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dal.Concrete.Repositories
{
    public class EfMessageRepository : EfGenericRepository<Message>, IMessageDal
    {

        private readonly TwitterContext _context;

        public EfMessageRepository(TwitterContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetOneToOneMessages(int activeUserId, int secondUserId)
        {
            return await _context.Messages.Where(x => x.RefId ==
            activeUserId && x.AppUserId == secondUserId || x.RefId == secondUserId && x.AppUserId == activeUserId).ToListAsync();
        }

        public async Task AddMessage(Message model,int activeUserId, int secondUserId)
        {
            model.AppUserId = activeUserId;
            model.RefId = secondUserId;

            await _context.Messages.AddAsync(model);
            await _context.SaveChangesAsync();
        }


    }
}
