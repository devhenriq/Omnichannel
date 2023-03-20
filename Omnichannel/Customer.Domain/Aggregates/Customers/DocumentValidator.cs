using System.Text.RegularExpressions;

namespace Customers.Domain.Aggregates.Customers
{
    public abstract class DocumentValidator
    {
        protected bool Validate(string document, string[] invalidDocuments, int[] firstMultipliers, int[] secondMultipliers)
        {
            if (!HasOnlyNumbers(document) || invalidDocuments.Contains(document))
                return false;

            var documentWithoutDigits = document.Substring(0, document.Length - 2);

            var firstDigit = GetDigit(documentWithoutDigits, firstMultipliers, document.Length);
            documentWithoutDigits = documentWithoutDigits + firstDigit;
            var digits = firstDigit + GetDigit(documentWithoutDigits, secondMultipliers, document.Length);

            return document.EndsWith(digits);

        }

        private bool HasOnlyNumbers(string document)
        {
            var validateRegex = new Regex($@"^\d{{{document.Length}}}$");
            return validateRegex.IsMatch(document);
        }

        private string GetDigit(string numbers, int[] multipliers, int size)
        {
            var total = 0;
            for (int i = 0; i < multipliers.Length; i++)
                total += int.Parse(numbers[i].ToString()) * multipliers[i];

            var remainder = total % size;
            return remainder < 2 ? "0" : (size - remainder).ToString();
        }
    }
}