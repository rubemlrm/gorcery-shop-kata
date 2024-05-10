using GroceryApi.Stocks;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger) {
            _logger = logger;
        }

        [HttpGet(Name = "GetItemPrice")]
        public IActionResult Get(string name)
        {
            if (string.IsNullOrEmpty(name)) {
                return BadRequest();
            }

            try
            {
                var stockService = new StockService();
                return Ok(stockService.GetProductPrice(name));
            }
            catch (ProductNotFoundExceptionException) {
                _logger.LogWarning("Product %name not found", name);
                return NotFound();
            }
            catch (System.Exception ex)
            {
                _logger.LogError("StockController.Get: throwed the following execption %s", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
