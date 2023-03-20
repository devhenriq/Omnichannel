using Customers.Infrastructure.HttpClients;
using Refit;

namespace Customers.Infrastructure.Providers.Cep
{
    public interface IViaCepClient
    {
        [Get("/ws/{cep}/json")]
        Task<ViaCepResponse> GetAddressAsync(string cep);
    }
}
