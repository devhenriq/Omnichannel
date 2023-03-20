using Companies.Domain.Aggregates;
using Companies.Infrastructure.Data;

namespace Companies.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _context;

        public CompanyRepository(CompanyContext context)
        {
            _context = context;
        }

        public void Create(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies.ToList();
        }
    }
}
