using FluentAssertions;

namespace MedHub.Core.Entities.Tests
{
    public class CabinetTests
    {
        [Fact]
        public void When_CreateCabinet_Then_ShouldReturnCabinet()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Cabinet.Create(sut.Item1, sut.Item2);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Address.Should().Be(sut.Item1);
            result.Entity.PhoneNumber.Should().Be(sut.Item2);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_CreateCabinetWithAddressNull_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result= Cabinet.Create(null, sut.Item2);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateCabinetWithAddressEmpty_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Cabinet.Create("", sut.Item2);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateCabinetWithPhoneNumberNull_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Cabinet.Create(sut.Item1, null);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_CreateCabinetWithPhoneNumberEmpty_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = Cabinet.Create(sut.Item1, "");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public void When_AttachSpecialityToCabinet_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            var medicalSpeciality = MedicalSpeciality.Create("Pediatrie").Entity;

            // Act
            var result = cabinet.AttachSpecialityToCabinet(medicalSpeciality);

            // Assert
            result.IsSuccess.Should().BeTrue();
            cabinet.Speciality.Should().Be(medicalSpeciality);
        }

        [Fact]
        public void When_AttachSpecialityToCabinetWithNullMedicalSpeciality_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.AttachSpecialityToCabinet(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.Speciality.Should().BeNull();
        }

        [Fact]
        public void When_AddDoctorsToCabinet_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            var doctor1 = Doctor.Create("75175290175", "Acsinte", "Ioana", "acsinte.ioana@ceva.ro", "0782415223").Entity;
            var doctor2 = Doctor.Create("1613634245", "Popescu", "Ionut", "popescu.ionut@ceva.ro", "0765718759").Entity;

            // Act
            var result = cabinet.AddDoctorsToCabinet(new List<Doctor> { doctor1, doctor2 });

            // Assert
            result.IsSuccess.Should().BeTrue();
            cabinet.Doctors.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddDoctorsToCabinetWithDoctorListNull_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.AddDoctorsToCabinet(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.Doctors.Should().BeEmpty();
        }

        [Fact]
        public void When_AddDoctorsToCabinetWithDoctorListEmpty_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.AddDoctorsToCabinet(new List<Doctor>());

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.Doctors.Should().BeEmpty();
        }

        [Fact]
        public void When_AddDrugsToCabinet_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            var drug1 = Drug.Create("Paracetamol", 35m, "Eficient impotriva racelii si gripei.").Entity;
            var drug2 = Drug.Create("Nurofen Forte", 41.5m, "Contine ibuprofen 400mg.").Entity;

            var paracetamol = StockItem.Create(50).Entity;
            var nurofenForte = StockItem.Create(100).Entity;

            paracetamol.AttachDrugToStockItem(drug1);
            nurofenForte.AttachDrugToStockItem(drug2);

            // Act
            var result = cabinet.AddDrugsToCabinet(new List<StockItem> { paracetamol, nurofenForte });

            // Assert
            result.IsSuccess.Should().BeTrue();
            cabinet.DrugStock.Should().HaveCount(2);
        }

        [Fact]
        public void When_AddDrugsToCabinetWithDrugsListNull_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.AddDrugsToCabinet(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.DrugStock.Should().BeEmpty();
        }

        [Fact]
        public void When_AdddrugsToCabinetWithDrugsListEmpty_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.AddDrugsToCabinet(new List<StockItem>());

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.DrugStock.Should().BeEmpty();
        }

        [Fact]
        public void When_BindAppointmentToCabinet_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            var startTime = DateTime.Now;
            var endTime = DateTime.Now.AddDays(2);
            var appointment = Appointment.Create(startTime, endTime).Entity;

            // Act
            var result = cabinet.BindAppointmentToCabinet(appointment);

            // Assert
            result.IsSuccess.Should().BeTrue();
            cabinet.CreatedAppointments.Should().HaveCount(1);
        }

        [Fact]
        public void When_BindAppointmentToCabinetWithNullAppointment_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.BindAppointmentToCabinet(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.CreatedAppointments.Should().BeEmpty();
        }

        [Fact]
        public void When_BindInvoiceToCabinet_Then_ShouldReturnSuccess()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            var invoice = Invoice.Create(DateTime.Now).Entity;

            // Act
            var result = cabinet.BindInvoiceToCabinet(invoice);

            // Assert
            result.IsSuccess.Should().BeTrue();
            cabinet.IssuedInvoices.Should().HaveCount(1);
        }

        [Fact]
        public void When_BindInvoiceToCabinetWithNullInvoice_Then_ShouldReturnFailure()
        {
            // Arrange
            var sut = CreateSUT();
            var cabinet = Cabinet.Create(sut.Item1, sut.Item2).Entity;

            // Act
            var result = cabinet.BindInvoiceToCabinet(null);

            // Assert
            result.IsFailure.Should().BeTrue();
            cabinet.IssuedInvoices.Should().BeEmpty();
        }

        /*
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
        */
        /*
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
                doctor.Cabinets.Should().Contain(cabinet);
            }

            // Assert
            cabinet.Doctors.Should().Contain(doctors);
            doctors[0].Cabinets.Should().Contain(cabinet);
            doctors[1].Cabinets.Should().Contain(cabinet);
        }
        */
        private static Tuple<string, string> CreateSUT()
        {
            return new Tuple<string, string>("sat Pildesti, com. Cordun, jud. Neamt", "0233780510");
        }
    }
}
