using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountsController : ControllerBase
  {
    private readonly IDrawMoneyService drawMoneyService; // DIP Application Layer

    public AccountsController(IDrawMoneyService drawMoneyService)
    {
      this.drawMoneyService = drawMoneyService;
    }

    [HttpPost("drawMoney")]
    public async Task<IActionResult> DrawMoney(DrawMoneyRequest request, CancellationToken token)
    {
      await this.drawMoneyService.HandleAsyc(request, CancellationToken.None);

      return Ok();
    }
  }
}
