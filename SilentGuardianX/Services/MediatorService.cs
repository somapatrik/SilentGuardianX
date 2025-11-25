using Mediator;

namespace SilentGuardianX.Services;

public class MediatorService
{
  public IMediator _mediator;
  
  public MediatorService(IMediator mediator)
  {
      _mediator = mediator;
  }
}