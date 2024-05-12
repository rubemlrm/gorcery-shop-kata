using GroceryApi.CartShop;
using GroceryApi.Stocks;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartShopController : ControllerBase
    {
        private readonly ILogger<CartShopController> _logger;

        private readonly StockRepository _stockRepository;

        public CartShopController(ILogger<CartShopController> logger, StockRepository repository)
        {
            _logger = logger;
            _stockRepository = repository;
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
                var carShopService = new CarShopService(_stockRepository);
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
