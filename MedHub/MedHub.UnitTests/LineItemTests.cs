using FluentAssertions;
using MedHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.UnitTests
{
    public class LineItemTests
    {

        [Fact]
        public void When_CreateLineItem_Then_ShouldReturnLineItem()
        {
            // Arrange

            // Act
            var result = new LineItem();

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }
    }
}
