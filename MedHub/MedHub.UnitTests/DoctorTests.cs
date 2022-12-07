using FluentAssertions;
using MedHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.UnitTests
{
    public class DoctorTests
    {
        [Fact]
        public void When_CreateDoctor_Then_ShouldReturnDoctor()
        {
            // Arrange
            Tuple<string, string, string, string> sut = CreateSUT();

            // Act
            var result = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.CNP.Should().Be(sut.Item1);
            result.Entity.FirstName.Should().Be(sut.Item2);
            result.Entity.LastName.Should().Be(sut.Item3);
            result.Entity.Email.Should().Be(sut.Item4);
            result.Entity.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_AddSpecialization_Then_ShouldSaveSpecialization()
        {
            // Arrange
            MedicalSpeciality medicalSpeciality = MedicalSpeciality.Create("Pneumolog").Entity;
            Tuple<string, string, string, string> sut = CreateSUT();
            Doctor doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4).Entity;

            // Act
            doctor.AddSpecialization(medicalSpeciality);

            // Assert
            doctor.Specializations.Contains(medicalSpeciality);
            doctor.Specializations.Count().Should().Be(1);
        }

        [Fact]
        public void When_SetCabinet_Then_ShouldSaveCabinet()
        {
            // Arrange
            Cabinet cabinet = Cabinet.Create("Iasi, Romania").Entity;
            Tuple<string, string, string, string> sut = CreateSUT();
            Doctor doctor = Doctor.Create(sut.Item1, sut.Item2, sut.Item3, sut.Item4).Entity;

            // Act
            doctor.SetCabinetToDoctor(cabinet);

            // Assert
            doctor.Cabinets.Contains(cabinet);
            doctor.Cabinets.Count().Should().Be(1);
        }
        Tuple<string, string, string, string> CreateSUT()
        {
            return new Tuple<string, string, string, string>(
                "1950430000000",
                "Florin - Marian",
                "Hazi",
                "florin@hazi"
                );
        }

    }
}
