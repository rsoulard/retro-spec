using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DTOs;
using RetroSpec.Core.OrganizationModels;

namespace RetroSpec.Application.DomainServices;

public class OrganizationService(IUnitOfWork unitOfWork) : IOrganizationService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<OrganizationDTO> CreateAsync(OrganizationCreateDTO newOrganization)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            var organization = Organization.Create(newOrganization.Name);
            await unitOfWork.OrganizationRepository.AddAsync(organization);
            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransactionAsync();

            return OrganizationDTO.FromOrganization(organization);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
