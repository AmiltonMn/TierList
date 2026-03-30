namespace api.TierList.Application.Base.Handlers;

public abstract class ApplicationBaseHandler
{
    protected readonly IApplicationBaseRepository<T> _repository;

    public ApplicationBaseHandler(IApplicationBaseRepository<T> repository)
    {
        _repository = repository;
    }
}