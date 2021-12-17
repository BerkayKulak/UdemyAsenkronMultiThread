using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TextWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
       
            try
            {
                _logger.LogInformation("İstek Başladı");
                //await Task.Delay(5000, token);
                //var myTask = new HttpClient().GetStringAsync("https://www.google.com");

                //var data = await myTask;

                Enumerable.Range(1, 10).ToList().ForEach(x =>
                {
                    Thread.Sleep(1000);
                    token.ThrowIfCancellationRequested();
                });

                _logger.LogInformation("istek bitti");

                return Ok("İşlemler bitti");
            }
            catch (Exception e)
            {
                _logger.LogInformation("İstep iptal edildi" + e.Message);
                return BadRequest();
            }
        }
    }
}
