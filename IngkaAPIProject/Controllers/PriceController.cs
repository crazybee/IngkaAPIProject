using IngkaAPIProject.Mocks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IngkaAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllPrices()
        {
            return Ok(MockedItems.MockPrices);
        }

        [HttpGet("filter")]
        [Authorize]
        public IActionResult GetPricesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var filteredPrices = MockedItems.MockPrices
                .Where(p => p.Date >= startDate && p.Date <= endDate)
                .ToList();

            return Ok(filteredPrices);
        }



    }
}
