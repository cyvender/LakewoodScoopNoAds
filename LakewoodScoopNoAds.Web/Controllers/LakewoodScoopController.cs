using LakewoodScoopNoAds.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LakewoodScoopNoAds.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LakewoodScoopController : ControllerBase
    {
        [HttpGet("GetArticles")]
        public List<Article> GetArticles()
        {
            var scraper = new Scraper();
            Console.WriteLine($"scraper: {scraper.GetArticles()}");
            return scraper.GetArticles();
        }
    }
}
