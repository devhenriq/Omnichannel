using CrossCutting.Exceptions;
using System.Text.RegularExpressions;

namespace Customers.Domain.Aggregates.Addresses.ValueObjects
{
    public class ZipCode
    {
        public ZipCode(string value)
        {
            if (!IsValid(value))
                throw new InvalidInputException(nameof(ZipCode));
            Value = value;
        }

        public string Value { get; set; }

        private bool IsValid(string value)
        {
            var validateRegex = new Regex(@"^\d{8}$", RegexOptions.Compiled);
            return validateRegex.IsMatch(value);
        }

    }
}
