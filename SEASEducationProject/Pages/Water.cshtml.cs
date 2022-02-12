using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEASEducationProject.ViewModels;
using System.Text;

namespace SEASEducationProject.Pages
{
    public class WaterModel : PageModel
    {
        [BindProperty]
        public Box BoxModel { get; set; }
        public string ErrorMessage { get; set; } = String.Empty;
        public string Result { get; set; } = String.Empty;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var volume = BoxModel.Volume;
            }
            else
            {
                ErrorMessage = String.Join(" ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            }
        }
    }
}
