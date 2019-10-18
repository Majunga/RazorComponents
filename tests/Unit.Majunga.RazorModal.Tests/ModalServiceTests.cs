using System;
using FluentAssertions;
using Majunga.RazorModal;
using Xunit;

namespace Unit.Majunga.RazorModal.Tests
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

        [Fact]
        public void Show_InvokesOnShow()
        {
            // arrange
            var actual = false;
            var modelService = new ModalService();
            modelService.OnShow += () => actual = true;

            // act
            modelService.Show();

            // assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Hide_InvokesOnHide()
        {
            // arrange
            var actual = false;
            var modelService = new ModalService();
            modelService.OnHide += () => actual = true;

            // act
            modelService.Hide();

            // assert
            actual.Should().BeTrue();
        }
    }
}
