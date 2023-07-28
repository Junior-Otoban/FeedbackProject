using FeedbackApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Infrastructure.Repositories
{
    public interface IFeedBackRepository : IGenericRepository<FeedBack>
    {
        Task<IEnumerable<FeedBack>> GetSentFeedbackLists(int id);
        Task<IEnumerable<FeedBack>> GetIncomingFeedbackLists(int id);
    }
}
