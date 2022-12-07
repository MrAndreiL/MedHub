﻿using FluentAssertions;
using MedHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.UnitTests
{
    public class MedicalSpecialityTests
    {
        [Fact]
        public void When_Create_MedicalSpeciality_Then_ShouldReturnMedicalSpeciality()
        {
            // Arrange
            string specializare = "Pneumolog";

            // Act
            var result = MedicalSpeciality.Create(specializare);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.SpecializationName.Should().Be(specializare);
            result.Entity.Id.Should().NotBeEmpty();
        }
    }
}
