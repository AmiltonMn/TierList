using AutoMapper;

namespace TierListAPI.Features.Submission.Delete;

public class DeleteSubmissionMapper : Profile
{
    public DeleteSubmissionMapper() 
    {
        CreateMap<DeleteSubmissionRequest, DeleteSubmissionResponse>();
    }
}
