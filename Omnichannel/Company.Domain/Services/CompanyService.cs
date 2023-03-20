using Companies.Domain.Aggregates;
using CrossCutting.Requests;

namespace Companies.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Create(CreateCompanyMessage request)
        {
            var company = new Company(request.CustomerId, request.SocialReason, request.StateSubscription);
            _companyRepository.Create(company);
        }
    }
}
