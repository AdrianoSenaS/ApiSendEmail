using ApiSendEmail.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailClcController : ControllerBase
    {
        // POST api/<SendEmailClcController>
        [HttpPost]
        public string Post(ServiceRequest service)
        {
           string email = "";//Substitua por email
            return SendEmailServices.Send(SendEmailServices.GenerateEmailClc(service), email, service.FullName);
        }

    }
}
