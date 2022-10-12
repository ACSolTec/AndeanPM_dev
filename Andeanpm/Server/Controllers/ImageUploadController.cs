using Andeanpm.Server.Services.OperationsService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IOperationsService operationsService;
        public ImageUploadController(IWebHostEnvironment webHostEnvironment, IOperationsService operationsService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.operationsService = operationsService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UploadImage uploadedImage)
        {
            try
            {
                if (uploadedImage.OldIamge != string.Empty)
                {
                    string oldUploadedImageFileName = uploadedImage.OldIamge.Split('/').Last();

                    System.IO.File.Delete($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\{uploadedImage.Folder}\\{oldUploadedImageFileName}");
                    
                }

                string guid = Guid.NewGuid().ToString();
                string imageFileName = guid + uploadedImage.NewImageFileExtension;

                string fullImageFileSystemPath = $"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\{uploadedImage.Folder}\\{imageFileName}";

                FileStream fileStream = System.IO.File.Create(fullImageFileSystemPath);
                byte[] imageContentAsByteArray = Convert.FromBase64String(uploadedImage.NewImageBase64Content);
                await fileStream.WriteAsync(imageContentAsByteArray, 0, imageContentAsByteArray.Length);
                fileStream.Close();

                string relativeFilePathWithoutTrailingSlashes = $"assets/{uploadedImage.Folder}/{imageFileName}";
                return Created("Create", relativeFilePathWithoutTrailingSlashes);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. Error message: {e.Message}");
            }
        }

        [HttpPost("uploadOperation/{id}")]
        public async Task<IActionResult> UploadOperation([FromBody] UploadImage uploadedImage, int id)
        {
            try
            {
                if (uploadedImage.OldIamge != string.Empty)
                {
                    string oldUploadedImageFileName = uploadedImage.OldIamge.Split('/').Last();

                    System.IO.File.Delete($"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\{uploadedImage.Folder}\\{oldUploadedImageFileName}");

                }

                string guid = Guid.NewGuid().ToString();
                string imageFileName = guid + uploadedImage.NewImageFileExtension;

                string fullImageFileSystemPath = $"{webHostEnvironment.ContentRootPath}\\wwwroot\\assets\\{uploadedImage.Folder}\\{imageFileName}";

                FileStream fileStream = System.IO.File.Create(fullImageFileSystemPath);
                byte[] imageContentAsByteArray = Convert.FromBase64String(uploadedImage.NewImageBase64Content);
                await fileStream.WriteAsync(imageContentAsByteArray, 0, imageContentAsByteArray.Length);
                fileStream.Close();

                string relativeFilePathWithoutTrailingSlashes = $"assets/{uploadedImage.Folder}/{imageFileName}";


                var resp = await operationsService.Get(id);

                resp.Data.ImageLink = relativeFilePathWithoutTrailingSlashes;

                await operationsService.Update(resp.Data);


                return Created("Create", relativeFilePathWithoutTrailingSlashes);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. Error message: {e.Message}");
            }
        }
    }
}
