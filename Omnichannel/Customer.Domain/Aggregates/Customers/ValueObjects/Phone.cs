using CrossCutting.Exceptions;
using System.Text.RegularExpressions;

namespace Customers.Domain.Aggregates.Customers.ValueObjects
{
    public class Phone
    {
        public Phone(string value)
        {
            Value = value;
            if (!IsValid(value))
                throw new InvalidInputException(nameof(Phone));
        }
        public string Value { get; private set; }

        private bool IsValid(string value)
        {
            var validateRegex = new Regex(@"^[0-9]{2}9?[0-9]{8}$", RegexOptions.Compiled);
            return validateRegex.IsMatch(value);
        }

    }
}
