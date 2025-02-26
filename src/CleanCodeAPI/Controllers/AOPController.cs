using Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AOPController : ControllerBase
  {
    private readonly IAccountService accountService; // DIP Inversion of Control


    public AOPController(IAccountService accountService)
    {
      this.accountService = accountService;
    }

    [HttpPost("drawMoney")]
    public IActionResult DrawMoney()
    {
      accountService.DrawMoney(100);
      return Ok();
    }
  }
}
