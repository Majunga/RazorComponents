using System;
using FluentAssertions;
using Majunga.BlazorModal;
using Xunit;

namespace Unit.Majunga.BlazorModal.Tests
{
    public class ModalServiceTests
    {
        [Fact]
        public void ToggleVisibility_InvokesOnToggle()
        {
            // arrange
            var onToggleInvoked = false;
            var modelService = new ModalService();
            modelService.OnToggle += () => onToggleInvoked = true;

            // act
            modelService.ToggleVisibility();

            // assert
            onToggleInvoked.Should().BeTrue();
        }
    }
}
