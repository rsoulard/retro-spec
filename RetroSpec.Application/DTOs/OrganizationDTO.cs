using RetroSpec.Core.OrganizationModels;

namespace RetroSpec.Application.DTOs;

public record OrganizationDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;

    public static OrganizationDTO FromOrganization(Organization organization)
    {
        return new()
        {
            Id = organization.Id,
            Name = organization.Name
        };
    }
}
