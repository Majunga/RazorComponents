using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Unit.Majunga.RazorModal.Tests")]
namespace Majunga.RazorModal
{
    public class ModalService : IModalService
    {
        public event Action OnToggle;
        public event Action OnShow;
        public event Action OnHide;

        public void ToggleVisibility()
        {
            this.OnToggle?.Invoke();
        }

        public void Show()
        {
            this.OnShow?.Invoke();
        }

        public void Hide()
        {
            this.OnHide?.Invoke();
        }
    }
}
