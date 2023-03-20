using CrossCutting.Exceptions;
using System.Text.RegularExpressions;

namespace Customers.Domain.Aggregates.Customers.ValueObjects
{
    public class Email
    {
        public Email(string value)
        {
            if (!IsValid(value))
                throw new InvalidInputException(nameof(Email));
            Value = value;
        }
        public string Value { get; private set; }


        private bool IsValid(string value)
        {
            var validateRegex = new Regex(@"^(\w[.\-_]?)+@+\w+\.+(\w)+(\.+\w+)*$", RegexOptions.Compiled);
            return validateRegex.IsMatch(value);
        }
    }
}
