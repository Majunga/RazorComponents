using FluentAssertions;
using Majunga.RazorModal;
using Xunit;

namespace Unit.Majunga.RazorModal.Tests
{
    public class ModalTests
    {
        [Fact]
        public void IsVisible_ShouldBeFalse()
        {
            // arrange
            var modal = new ModalBaseWrapper();
            modal.PublicModalService = CreateModalService();

            // act
            modal.PublicOnInitialized();

            // assert
            modal.PublicIsVisible.Should().BeFalse();
        }

        [Fact]
        public void OnShow_IsVisible_ShouldBeTrue()
        {
            // arrange
            var modal = new ModalBaseWrapper();
            modal.PublicModalService = CreateModalService();
            modal.PublicOnInitialized();

            // act
            modal.PublicModalService.Show();

            // assert
            modal.PublicIsVisible.Should().BeTrue();
        }

        [Fact]
        public void OnHide_IsVisible_ShouldBeTrue()
        {
            // arrange
            var modal = new ModalBaseWrapper();
            modal.PublicModalService = CreateModalService();
            modal.PublicOnInitialized();
            modal.PublicModalService.Show();

            // act
            modal.PublicModalService.Hide();

            // assert
            modal.PublicIsVisible.Should().BeFalse();
        }
        
        [Fact]
        public void OnToggle_IsVisible_ShouldBeSetCorrectly()
        {
            // arrange
            var modal = new ModalBaseWrapper();
            modal.PublicModalService = CreateModalService();
            modal.PublicOnInitialized();

            // act & assert
            modal.PublicModalService.ToggleVisibility();
            modal.PublicIsVisible.Should().BeTrue();

            modal.PublicModalService.ToggleVisibility();
            modal.PublicIsVisible.Should().BeFalse();
        }

        private ModalService CreateModalService()
        {
            var service = new ModalService();
            return service;
        }
    }

    public class ModalBaseWrapper : ModalBase
    {
        public ModalService PublicModalService
        {
            get => base.ModalService; 
            set 
            {
                base.ModalService = value;
            }
        }

        public bool PublicIsVisible => base.IsVisible;

        public void PublicOnInitialized()
        {
            base.OnInitialized();
        }
    }
}
