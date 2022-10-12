using Andeanpm.Client.Components.Public;
using Andeanpm.Server.Providers;
using Andeanpm.Server.Services.FormService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace Andeanpm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly SmptSettings smtpSettings;

        private readonly IFormService formService;

        private readonly IWebHostEnvironment webHostEnvironment;

        private MailProvider mail = new();

        public FormsController(IOptions<SmptSettings> smtpSettings, IFormService formService, IWebHostEnvironment webHostEnvironment)
        {
            this.smtpSettings = smtpSettings.Value;  
            this.formService = formService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("application")]
        public async Task<ActionResult<ServiceResponse<Application>>> Application(Application application)
        {
            ServiceResponse<Application> response = new ServiceResponse<Application>();

            try
            {
                string clientPath = $"{webHostEnvironment.ContentRootPath}wwwroot\\assets\\careers\\Resume-{application.Name}.pdf";

                FileStream fileStream = System.IO.File.Create(clientPath);
                byte[] bytes = Convert.FromBase64String(application.Resume.NewImageBase64Content);

                await fileStream.WriteAsync(bytes, 0, bytes.Length);
                fileStream.Close();

                application.ResumeId = $"assets/careers/Resume-{application.Name}.pdf";

                response = await formService.Application(application);

                mail.MailSuscribeCustomer<Application>(application, $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}", smtpSettings, webHostEnvironment);

                return Ok(response);

            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = $"{e.Message} - {e.InnerException}";
                return Ok(response);
            }
        }

        [HttpGet("pagination/application"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetApplication([FromQuery] PaginationParameters paginationParameters)
        {
            var result = await formService.GetApplication(paginationParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("pagination/contact"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetContact([FromQuery] PaginationParameters paginationParameters)
        {

            var result = await formService.GetContact(paginationParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet("pagination/subscriber"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSubscriber([FromQuery] PaginationParameters paginationParameters)
        {

            var result = await formService.GetSubscriber(paginationParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpPost("contact")]
        public async Task<ActionResult<ServiceResponse<Contact>>> Contact(Contact contact)
        {
            var result = await formService.Contact(contact);
            mail.MailSuscribeCustomer<Contact>(contact, $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}", smtpSettings, webHostEnvironment);
            return Ok(result);
        }

        [HttpPost("subscription")]
        public async Task<ActionResult<ServiceResponse<Subscriber>>> Subscription(Subscriber subscriber)
        {
            ServiceResponse<Subscriber> response = new ServiceResponse<Subscriber>();
            try
            {
                var subs = await formService.GetSubscriber(subscriber.Email);

                if (subs == null)
                {
                    subscriber.EndDate = null;
                    response = await formService.Subscription(subscriber);
                    response.Success = true;
                    response.Message = "Please check the email we sent you to confirm your subscription";

                }
                if (subs != null && subs.IsSubscriber == 1)
                {
                    response.Data = subs;
                    response.Success = false;
                    response.Message = "You're already subscribed!, This email is already subscribed";
                }
                if (subs != null && (subs.IsSubscriber == 2 || subs.IsSubscriber == 0))
                {
                    response.Data = subs;
                    response.Success = true;
                    response.Message = "Please check the email we sent you to confirm your subscription";

                }
                if(response.Success) mail.MailSuscribeCustomer<Subscriber>(subscriber, $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}", smtpSettings, webHostEnvironment);

            }
            catch(Exception ex)
            {
                response.Data = new Subscriber();
                response.Success = false;
                response.Message = "At the moment we cannot suscribe you, please try again later.";
            }

            return Ok(response);
        }

        [HttpPost("updateSubscription")]
        public async Task<ActionResult<ServiceResponse<Subscriber>>> UpdateSubscription(Subscriber subscriber)
        {
            ServiceResponse<Subscriber> response = new ServiceResponse<Subscriber>();

            var subs = await formService.GetSubscriber(subscriber.Email);

            try
            {
                subs.IsSubscriber = subscriber.IsSubscriber;

                subs.EndDate = subscriber.IsSubscriber == 1 ? null : DateTime.Now;

                response = await formService.UpdateSubscriber(subs);
            }
            catch (Exception ex)
            {
                response.Data = new Subscriber();
                response.Success = false;
                response.Message = string.Empty;
            }

            return Ok(response);
        }
    }
}
