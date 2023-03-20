namespace Customers.Domain.Aggregates.Customers
{
    public interface IDocumentValidator
    {
        bool Validate(string value);
    }
}
