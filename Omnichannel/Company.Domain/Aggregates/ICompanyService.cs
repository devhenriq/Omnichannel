using CrossCutting.Requests;

namespace Companies.Domain.Aggregates
{
    public interface ICompanyService
    {
        void Create(CreateCompanyMessage request);
    }
}
