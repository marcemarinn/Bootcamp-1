using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;

namespace Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly Bootcampp2Context _bootcampp2Context;

    public CompanyRepository(Bootcampp2Context bootcampp2Context)
    {
        _bootcampp2Context = bootcampp2Context;
    }

    public async Task<CompanyDTO> Create(CreateCompanyRequest request)
    { 
    
        var companyToCreate =  request.Adapt<Company>();

        _bootcampp2Context.Companies.Add(companyToCreate);

        await _bootcampp2Context.SaveChangesAsync();

        var companyDTO = request.Adapt<CompanyDTO>();

        return companyDTO;

    }
}
