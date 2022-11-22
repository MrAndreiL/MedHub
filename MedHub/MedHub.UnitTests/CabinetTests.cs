using FluentAssertions;
using MedHub.Domain.Models;

namespace MedHub.UnitTests
{
    public class CabinetTests
    {
        [Fact]
        public void When_AddingDrugsToCabineStock_Then_ShouldReturnSucces()
        {
            var cabinet = new Cabinet("Strada Mihai Eminescu");
            var drug1 = new Drug("paracetamol", "anti febra", 10);
            var drug2 = new Drug("sumedon", "anti virus", 20);

            var stockLineItems = new List<StockLineItem>()
            {
               new StockLineItem(),
               new StockLineItem(),
            };

            stockLineItems[0].AddDrugAndQuantityToLineItem(drug1, 100);
            stockLineItems[1].AddDrugAndQuantityToLineItem(drug2, 100);

            var result =cabinet.AddDrugsToCabinetStock(stockLineItems);
            var resultFail = cabinet.AddDrugsToCabinetStock(new List<StockLineItem>());

            stockLineItems[0].Should().NotBeNull();
            stockLineItems[0].Drug.Should().Be(drug1);
            stockLineItems[0].DrugId.Should().Be(drug1.Id);
            stockLineItems[0].Quantity.Should().Be(100);
            
            stockLineItems[0].Cabinet.Should().NotBeNull();
            stockLineItems[0].Cabinet.Should().Be(cabinet);
            stockLineItems[0].CabinetId.Should().Be(cabinet.Id);

            result.IsSuccess.Should().Be(true);
            resultFail.IsSuccess.Should().Be(false);
        }
        [Fact]
        public void When_AddingDoctorsToCabinet_Then_DoctorsShouldHaveCabinetAssigned()
        {
            var cabinet = new Cabinet("Strada Mihai Eminescu");

            var doctors = new List<Doctor>()
            {
                new Doctor("6221113017906", "Popescu", "Ion", "popescuion2222@mail.com"),
                new Doctor("0201013017906", "Egidiu", "Farcas", "farcas_egidiu@hotmail.com"),
            };

            var result = cabinet.AddDoctorsListToCabinet(doctors);
            var resultFail = cabinet.AddDoctorsListToCabinet(new List<Doctor>());

            foreach (var doctor in cabinet.Doctors)
            {
                doctor.Should().NotBeNull();
                doctor.Cabinet.Should().Be(cabinet);
                doctor.Cabinet.Id.Should().Be(cabinet.Id);
            }
            result.IsSuccess.Should().Be(true);
            resultFail.IsSuccess.Should().Be(false);


        }
    }
}
