namespace Customers.Domain.Aggregates.Customers.Strategies
{
    public class CpfValidatorStrategy : DocumentValidator, IDocumentValidator
    {
        private readonly string[] _invalidCpfs = {
            "00000000000", "11111111111", "22222222222",
            "33333333333", "44444444444", "55555555555",
            "66666666666", "77777777777", "88888888888", "99999999999"
        };

        private readonly int[] _firstMultipliers = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] _secondMultipliers = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public bool Validate(string value)
        {
            return Validate(11, value, _invalidCpfs, _firstMultipliers, _secondMultipliers);
        }
    }
}
