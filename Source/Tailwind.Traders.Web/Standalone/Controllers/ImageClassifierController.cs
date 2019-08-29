using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tailwind.Traders.Web.Standalone.Controllers
{
    [ApiController]
    public class ImageClassifierController : Controller
    {
        private readonly IProductService productService;
        private readonly IImageSearchService imageSearchService;

        public ImageClassifierController(
            IProductService productService,
            IImageSearchService imageSearchService)
        {
            this.productService = productService;
            this.imageSearchService = imageSearchService;
        }

        [HttpPost("api/v1/products/imageclassifier")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostImage(IFormFile file)
        {
            var products = await imageSearchService.GetProducts(file.OpenReadStream());
            return Ok(products);
        }
    }
}