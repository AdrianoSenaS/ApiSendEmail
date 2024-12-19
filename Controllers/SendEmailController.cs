using ApiSendEmail.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
       
        // POST api/<SendEmailController>
        [HttpPost]
        public string Post(RegistrationForm form)
        {
           return SendEmailServices.Send(SendEmailServices.GenerateEmailBody(form), form.Email, form.FullName);
        }
    }
}
