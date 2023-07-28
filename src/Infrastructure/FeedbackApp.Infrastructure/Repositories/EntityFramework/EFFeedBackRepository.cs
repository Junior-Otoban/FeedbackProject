using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Infrastructure.Repositories.EntityFramework
{
    public class EFFeedBackRepository : EFRepositoryBase<FeedBack,FeedBackContext>,IFeedBackRepository
    {
        private readonly FeedBackContext _context;
        public EFFeedBackRepository(FeedBackContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedBack>> GetIncomingFeedbackLists(int id)
        {
            var receiverMail = _context.Users.Where(u => u.Id == id).Select(u => u.Email).First();
            return await _context.FeedBacks.Where(f => f.ReceiverMail == receiverMail).ToListAsync();   
        }

        public async Task<IEnumerable<FeedBack>> GetSentFeedbackLists(int id)
        {
            var sendermail = _context.Users.Where(u => u.Id == id).Select(u => u.Email).First();

            return await _context.FeedBacks.Where(f => f.SenderMail == sendermail).ToListAsync();             
        }
    }
}
