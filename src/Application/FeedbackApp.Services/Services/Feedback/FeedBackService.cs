using AutoMapper;
using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.DataTransferObjects.Responses;
using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Services.Feedback
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedBackRepo;
        private readonly IMapper _mapper;

        public FeedBackService(IFeedBackRepository feedBackRepo, IMapper mapper)
        {
            _feedBackRepo = feedBackRepo;
            _mapper = mapper;
        }

        public async Task CreateFeedBack(CreateFeedBackRequest model)
        {
            var feedback = _mapper.Map<FeedBack>(model);
            await _feedBackRepo.AddAsync(feedback);
        }

        public async Task DeleteFeedBack(FeedBack entity)
        {
            await _feedBackRepo.DeleteAsync(entity);
        }

        public Task<FeedBack?> GetFeedbackById(int id)
        {
            return _feedBackRepo.GetAsync(id);
        }

        public async Task<IEnumerable<FeedBackListResponse>> GetFeedbackList()
        {
            var feedbacks = await _feedBackRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedBackListResponse>>(feedbacks);
        }

        public async Task<IEnumerable<FeedBackListResponse>> GetIncomingFeedback(int id)
        {
            var feedbacks = await _feedBackRepo.GetIncomingFeedbackLists(id);
            return _mapper.Map<IEnumerable<FeedBackListResponse>>(feedbacks);
        }

        public async Task<IEnumerable<FeedBackListResponse>> GetSentFeedbacks(int id)
        {
            var feedbacks = await _feedBackRepo.GetSentFeedbackLists(id);
            return _mapper.Map<IEnumerable<FeedBackListResponse>>(feedbacks);
        }

        public async Task UpdateFeedBack(UpdateFeedBackRequest model)
        {
            var feedback = _mapper.Map<FeedBack>(model);
            await _feedBackRepo.UpdateAsync(feedback);
        }
    }
}
