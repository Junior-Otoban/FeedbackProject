using AutoMapper;
using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateFeedBackRequest,FeedBack>();
        }
    }
}
