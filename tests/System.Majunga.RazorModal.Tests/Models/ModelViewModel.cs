using System.ComponentModel.DataAnnotations;

namespace Majunga.RazorComponent.UI.Models
{
    public class ModelViewModel
    {
        [Required]
        public string Name {get;set;}
    }
}
