using RetroSpec.Application.DTOs;

namespace RetroSpec.Application.Abstractions;

public interface IOrganizationService
{
    Task<OrganizationDTO> CreateAsync(OrganizationCreateDTO newOrganization);
}