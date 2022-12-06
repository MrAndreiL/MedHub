using FluentAssertions;
using MedHub.Domain.Helpers;
using MedHub.Domain.Interfaces;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class CabinetTests
    {
        [Fact]
        public void When_CreateCabinet_Then_ShouldReturnCabinet()
        {
            // Arrange
            Tuple<string> sut = CreateSUT();

            // Act
            var result = Cabinet.Create(sut.Item1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Address.Should().Be(sut.Item1);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_AddingDrugsToCabineStock_Then_ShouldReturnSucces()
        {
            // Arrange
            Tuple<string> sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1).Entity;

            var drug1 = Drug.Create("paracetamol", "anti febra", 10).Entity;
            var drug2 = Drug.Create("sumedon", "anti virus", 20).Entity;

            var stockLineItems = new List<StockLineItem>()
            {
               new StockLineItem(),
               new StockLineItem(),
            };

            stockLineItems[0].AddDrugAndQuantityToLineItem(drug1, 100);
            stockLineItems[1].AddDrugAndQuantityToLineItem(drug2, 100);

            // Act
            var result =cabinet.AddDrugsToCabinetStock(stockLineItems);
            var resultFail = cabinet.AddDrugsToCabinetStock(new List<StockLineItem>());

            // Assert
            stockLineItems[0].Should().NotBeNull();
            stockLineItems[0].Drug.Should().Be(drug1);
            stockLineItems[0].Quantity.Should().Be(100);
            stockLineItems[0].Cabinet.Should().Be(cabinet);

            result.IsSuccess.Should().Be(true);
            resultFail.IsSuccess.Should().Be(false);
        }
        [Fact]
        public void When_AddingDoctorsToCabinet_Then_DoctorsShouldHaveCabinetAssigned_And_Cabinet_Should_Contain_Doctors()
        {
            // Arrange
            Tuple<string> sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1).Entity;

            var doctors = new List<Doctor>()
            {
                Doctor.Create("6221113017906", "Popescu", "Ion", "popescuion2222@mail.com").Entity,
                Doctor.Create("0201013017906", "Egidiu", "Farcas", "farcas_egidiu@hotmail.com").Entity,
            };

            // Act
            var result = cabinet.AddDoctorsListToCabinet(doctors);

            foreach (var doctor in cabinet.Doctors)
            {
                doctor.Should().NotBeNull();
                doctor.Cabinet.Should().Contain(cabinet);
            }

            // Assert
            cabinet.Doctors.Should().Contain(doctors);
            doctors[0].Cabinet.Should().Contain(cabinet);
            doctors[1].Cabinet.Should().Contain(cabinet);
        }

        [Fact]
        private Tuple<string> CreateSUT()
        {
            Tuple<string> sut = new Tuple<string>("sat Pildesti, com. Cordun, jud. Neamt");

            return sut;
        }
    }
}
