using System.ComponentModel.DataAnnotations;

namespace SEASEducationProject.ViewModels
{
    public class Box
    {
        [Required]
        [Range(0, 999.99)]
        public decimal Length { get; set; }
        [Range(0, 999.99)]
        [Required]
        public decimal Width { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal Height { get; set; }

        public decimal Volume
        { 
            get 
            {
                return Length * Width * Height;
            } 
        }
    }
}
