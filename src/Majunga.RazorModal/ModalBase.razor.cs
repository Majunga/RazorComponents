using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit.Majunga.RazorModal.Tests")]
namespace Majunga.RazorModal
{
    public class ModalBase : ComponentBase, IDisposable
    {

        #region Parameters

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> SaveHandler { get; set; }

        #endregion

        [Inject]
        protected ModalService ModalService { get; set; }

        protected bool IsVisible { get; set; }
        protected string Display => IsVisible ? "block" : "none";
        protected string CssClass => IsVisible ? "fade show" : "fade";

        protected void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ModalService.OnToggle += ToggleVisibility;

            ModalService.OnShow += () => this.IsVisible = true;
            ModalService.OnHide += () => this.IsVisible = false;
        }

        public void Dispose()
        {
            ModalService.OnToggle -= ToggleVisibility;
            ModalService.OnShow -= () => this.IsVisible = true;
            ModalService.OnHide -= () => this.IsVisible = false;
        }
    }
}
