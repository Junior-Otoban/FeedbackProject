using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Context;
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
    }
}
