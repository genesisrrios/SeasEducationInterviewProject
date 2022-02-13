using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEASEducationProject.ViewModels;
using System.Globalization;

namespace SEASEducationProject.Pages
{
    public class WeekModel : PageModel
    {
        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public List<NameDate> NamesAndDates { get; set; }
        
        public void OnGet()
        {
        }
        public async Task OnPostAsync()
        {
            if (FileUpload != null)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(filePath))
                {
                    await FileUpload.CopyToAsync(stream);
                }
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                };
                IEnumerable<NameDate> records = new List<NameDate>();
                NamesAndDates = new List<NameDate>();

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    records = csv.GetRecords<NameDate>().ToList();
                }
                foreach (var record in records)
                {
                    var newDateAndName = new NameDate { Name = record.Name };
                    var dateWasParsed = DateTime.TryParse(record.Date, out DateTime result);
                    newDateAndName.Date = dateWasParsed ? result.Date.ToString("yyyy-MM-dd") : String.Empty;
                    NamesAndDates.Add(newDateAndName);
                }
            }
        }
    }
}
