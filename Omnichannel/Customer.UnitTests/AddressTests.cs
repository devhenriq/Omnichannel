using Customers.Domain.Aggregates.Addresses;
using Customers.UnitTests.Factories;
using FluentAssertions;

namespace Customers.UnitTests
{
    public class AddressTests : UnitTest
    {
        [Fact(DisplayName = "Constructor should create an Address with specific zip code")]
        public void ConstructorShouldCreateAnAddress()
        {
            //Arrange
            var zipCode = _faker.Address.ZipCode();

            //Act
            var address = new Address(zipCode, _faker.Address.City(), _faker.Address.State(), _faker.Address.StreetName(), _faker.Address.StreetAddress());

            //Assert
            address.ZipCode.Should().Be(zipCode);
        }

        [Fact(DisplayName = "SetAdditionalInformation should change additional information fields")]
        public void SetAdditionalInformationShouldChangeAdditionInformationFields()
        {
            //Arrange
            var address = AddressFactory.CreateAddressMock();

            var expectedBuildingNumber = _faker.Address.BuildingNumber();
            //Act
            address.SetAdditionalInformation(expectedBuildingNumber, _faker.Random.String2(10), _faker.Random.String2(10), _faker.Random.String2(10));

            //Assert
            address.Number.Should().Be(expectedBuildingNumber);
        }
    }
}