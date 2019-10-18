using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Unit.Majunga.RazorModal.Tests")]
namespace Majunga.RazorModal
{
    public class ModalService
    {
        internal event Action OnToggle;

        public void ToggleVisibility()
        {
            OnToggle?.Invoke();
        }
    }
}
