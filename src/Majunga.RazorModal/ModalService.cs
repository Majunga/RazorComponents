using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Unit.Majunga.BlazorModal.Tests")]
namespace Majunga.BlazorModal
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
