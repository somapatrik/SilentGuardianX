using SilentGuardian.Application.DTOs.Endpoints;
using SilentGuardian.Domain.Checks;
using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Application.Mappers.Interfaces;

public interface IAppMapper
{
    EndpointGroupDTO ToDTO(EndpointGroup endpointGroup);
    EndpointDTO ToDTO(Endpoint endpoint);
    EndpointResultDTO ToDTO(EndpointResult endpointResult);
    CheckMethodDTO ToDTO(CheckMethod checkMethod);
}