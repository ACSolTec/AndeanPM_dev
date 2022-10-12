using Andeanpm.Shared.Models;

namespace Andeanpm.Client.Services.UploadImageService
{
	public interface IUploadImageService
	{
		Task<HttpResponseMessage> UploadedImage(UploadImage uploadedImage);
		Task<HttpResponseMessage> UploadedOperation(UploadImage uploadedImage, int id);

    }
}
