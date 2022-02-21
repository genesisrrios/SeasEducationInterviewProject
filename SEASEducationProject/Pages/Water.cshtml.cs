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
            //4 5 6 - 33.5480
            if (ModelState.IsValid)
            {
                var volume = BoxModel.Volume;
                var boxVolumeInmilliliters = volume * (decimal)16.3871;
                var boxVolumeInliters = boxVolumeInmilliliters / 1000;
                var wholeVolumeNumberInLiters = Math.Ceiling(boxVolumeInliters);
                var wholeVolumeNumberInMililiters = wholeVolumeNumberInLiters * 1000;
                var calc = Math.Round(wholeVolumeNumberInMililiters - boxVolumeInmilliliters, 4);
                if (calc == 0) calc = 1000;

                Result = $"For a box with a volume of {volume} inches the difference in millimeters between {wholeVolumeNumberInLiters}L and the volume is: { calc }mL.";
            }
            else
            {
                ErrorMessage = string.Join(" ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            }
        }
    }
}
