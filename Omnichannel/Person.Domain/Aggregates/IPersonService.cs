using CrossCutting.Requests;

namespace People.Domain.Aggregates
{
    public interface IPersonService
    {
        void Create(CreatePersonMessage request);
    }
}
