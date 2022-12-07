using FluentAssertions;
using MedHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.UnitTests
{
    public class MedicalRecordTests
    {
        [Fact]
        public void When_CreateMedicalRecord_Then_ShouldReturnMedicalRecord()
        {
            // Arrange
            Doctor doctor = Doctor.Create("1950430000000", "Florin - Marian", "Hazi", "florin@hazi").Entity;
            Patient patient = Patient.Create("1950430000000", "Florin - Marian", "Hazi", "florin@hazi").Entity;

            // Act
            var result = MedicalRecord.Create(doctor, patient, "Sanatos tun");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Doctor.Should().Be(doctor);
            result.Entity.Patient.Should().Be(patient);
            result.Entity.Id.Should().NotBeEmpty();
        }
    }
}
