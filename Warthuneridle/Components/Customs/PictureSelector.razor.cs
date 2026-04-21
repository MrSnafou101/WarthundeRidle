using Microsoft.AspNetCore.Mvc;

namespace Warthuneridle.Components.Customs
{
    public partial class PictureSelector{
        [BindProperty]
        public IFormFile VehiclePicture { get; set; }

        public async Task OnPostAsync(){
            var file = Path.Combine(environment.ContentRootPath, "images", VehiclePicture.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await VehiclePicture.CopyToAsync(fileStream);
            }
        }
    }
}
