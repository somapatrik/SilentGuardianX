using SilentGuardian.Application.DTOs.Endpoints;
using SilentGuardian.Application.Mappers.Interfaces;
using SilentGuardian.Domain.Checks;
using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Application.Mappers;

public class AppMapper : IAppMapper
{
    public EndpointGroupDTO ToDTO(EndpointGroup endpointGroup)
    {
        return new EndpointGroupDTO()
        {
            Id =  endpointGroup.Id,
            GroupName = endpointGroup.GroupName,
            Description = endpointGroup.Description,
            IsEnabled = endpointGroup.IsEnabled,
            Endpoints = endpointGroup.Endpoints.Select(ToDTO).ToList(),
            Result = endpointGroup.Result,
        };
    }

    public EndpointDTO ToDTO(Endpoint endpoint)
    {
        return new EndpointDTO()
        {
            Id = endpoint.Id,
            Name = endpoint.Name,
            Description = endpoint.Description,
            IpAddress =  endpoint.IpAddress,
            IsEnabled = endpoint.IsEnabled,
            Result = ToDTO(endpoint.Result),
            CheckMethods = endpoint.CheckMethods.Select(ToDTO).ToList(),
            Timeout = endpoint.Timeout,
        };
    }

    public EndpointResultDTO ToDTO(EndpointResult endpointResult)
    {
        return (EndpointResultDTO)endpointResult;
    }

    public CheckMethodDTO ToDTO(CheckMethod checkMethod)
    {
        return new CheckMethodDTO()
        {
            Id = checkMethod.Id,
            LastCheck =  checkMethod.LastCheck,
            LastResult = checkMethod.LastResult,
            Timeout =  checkMethod.Timeout,
            TimeoutLimit = checkMethod.TimeoutLimit,
        };
    }
}