using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Unit.Majunga.RazorModal.Tests")]
namespace Majunga.RazorModal
{
    public class ModalService
    {
        internal event Action OnToggle;

        internal event Action OnShow;
        internal event Action OnHide;

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
