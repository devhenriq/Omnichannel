namespace Customers.Domain.Aggregates.Customers.Strategies
{
    public class CnpjValidatorStrategy : DocumentValidator, IDocumentValidator
    {
        private readonly string[] _invalidCnpjs = {
                "00000000000000", "11111111111111", "22222222222222", "33333333333333",
                "44444444444444", "55555555555555", "66666666666666", "77777777777777",
                "88888888888888", "99999999999999",
            };

        private readonly int[] _firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] _secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validate(string value)
        {
            return Validate(value, _invalidCnpjs, _firstMultiplier, _secondMultiplier);
        }
    }
}
