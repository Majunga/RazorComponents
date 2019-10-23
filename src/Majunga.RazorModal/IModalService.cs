using System;
using System.Collections.Generic;
using System.Text;

namespace Majunga.RazorModal
{
    public interface IModalService
    {
        void ToggleVisibility();
        void Show();
        void Hide();
    }
}
