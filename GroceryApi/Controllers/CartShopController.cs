using GroceryApi.CartShop;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartShopController : ControllerBase
    {
        private readonly ILogger<CartShopController> _logger;

        public CartShopController(ILogger<CartShopController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostShopOrder")]
        public IActionResult Post(CartShopRequest request)
        {
            if (!request.Items.Any())
            {
                return BadRequest();
            }

            try
            {
                var carShopService = new CarShopService();
                return Ok(carShopService.CalculateCartShopPrice(request));
            }
            catch (System.Exception ex)
            {
                _logger.LogError("StockController.Get: throwed the following execption %s", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
