using CrossCutting.Exceptions;

namespace Customers.Domain.Aggregates.Customers.ValueObjects
{
    public class Document
    {
        public string Value { get; private set; } = "";

        public Document(string value, IDocumentValidator validator)
        {
            if (!validator.Validate(value)) throw new InvalidInputException(nameof(Document));
            Value = value;
        }

        private Document() { }
    }
}
