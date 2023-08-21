using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController
    {
        [HttpGet]
        public string TesteGet()
        {
            return "teste";
        }
    }
}
