using System.Text.RegularExpressions;

namespace Customers.Domain.Aggregates.Customers
{
    public abstract class DocumentValidator
    {
        protected bool Validate(int expectedLength, string document, string[] invalidDocuments, int[] firstMultipliers, int[] secondMultipliers)
        {
            if (expectedLength != document.Length || !HasOnlyNumbers(document) || invalidDocuments.Contains(document))
                return false;

            var documentWithoutDigits = document.Substring(0, expectedLength - 2);

            var firstDigit = GetDigit(documentWithoutDigits, firstMultipliers);
            documentWithoutDigits = documentWithoutDigits + firstDigit;
            var digits = firstDigit + GetDigit(documentWithoutDigits, secondMultipliers);

            return document.EndsWith(digits);

        }

        private bool HasOnlyNumbers(string document)
        {
            var validateRegex = new Regex($@"^\d{{{document.Length}}}$");
            return validateRegex.IsMatch(document);
        }

        private string GetDigit(string numbers, int[] multipliers)
        {
            var total = 0;
            for (int i = 0; i < multipliers.Length; i++)
                total += int.Parse(numbers[i].ToString()) * multipliers[i];

            var remainder = total % 11;
            return remainder < 2 ? "0" : (11 - remainder).ToString();
        }
    }
}