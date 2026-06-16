using AutoMapper;

namespace TierListAPI.Features.Submission.Create;

public class SubmissionCreateMapper : Profile
{
    public SubmissionCreateMapper() 
    {
        CreateMap<SubmissionCreateRequest, SubmissionCreateResponse>();
    }
}
