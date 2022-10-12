using Andeanpm.Shared.Models;
using System.Net.Http.Json;

namespace Andeanpm.Client.Services.UploadImageService
{
	public class UploadImageService : IUploadImageService
    {
        private readonly HttpClient httpClient;

        public UploadImageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> UploadedImage(UploadImage uploadedImage) {
            return await httpClient.PostAsJsonAsync<UploadImage>("api/imageupload", uploadedImage);
        }
        
        public async Task<HttpResponseMessage> UploadedOperation(UploadImage uploadedImage, int id) {
            return await httpClient.PostAsJsonAsync<UploadImage>($"api/imageupload/uploadOperation/{id}", uploadedImage);
        }
    }
}
