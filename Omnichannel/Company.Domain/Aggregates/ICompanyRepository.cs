namespace Companies.Domain.Aggregates
{
    public interface ICompanyRepository
    {
        void Create(Company company);
        IEnumerable<Company> GetAll();
    }
}
