using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEASEducationProject.ViewModels;
using System.Text;

namespace SEASEducationProject.Pages
{
    public class WaterModel : PageModel
    {
        [BindProperty]
        public Box BoxModel { get; set; } = new Box();
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
                var boxVolumeInmilliliters = volume * (decimal)16.3871;
                var boxVolumeInliters = boxVolumeInmilliliters / 1000;
                var wholeVolumeNumberInLiters = Math.Truncate(Math.Round(boxVolumeInliters, 4));
                Result = $"For a box with a volume of {volume} inches the difference betwen millimeters and the next liter is { boxVolumeInliters - boxVolumeInmilliliters }.";
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
