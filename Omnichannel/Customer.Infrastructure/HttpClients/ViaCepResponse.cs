using Customers.Domain.Aggregates.Addresses;

namespace Customers.Infrastructure.HttpClients
{
    public class ViaCepResponse
    {
        public ViaCepResponse(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string ddd, string siafi, bool erro)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            Ddd = ddd;
            Siafi = siafi;
            Erro = erro;
        }

        public string Cep { get; }
        public string Logradouro { get; }
        public string Complemento { get; }

        public string Bairro { get; }

        public string Localidade { get; }

        public string Uf { get; }

        public string Ibge { get; }

        public string Gia { get; }

        public string Ddd { get; }

        public string Siafi { get; }
        public bool Erro { get; private set; } = false;

        public Address ToDomain() => new Address(Cep, Localidade, Uf, Logradouro, Bairro);
    }
}