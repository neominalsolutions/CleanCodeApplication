using Infrastructure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OpenClosedsController : ControllerBase
  {

    private readonly IRepository repository;
    // Not: bir interface birden fazla sınıftan Open Closed ile implemente oluyorsa IServiceScopeFactory yöntemi ile ilgili servis parametre bazlı çağırılabilir.
    private readonly IServiceScopeFactory serviceScopeFactory;

    public OpenClosedsController(IRepository repository, IServiceScopeFactory serviceScopeFactory)
    {
      this.serviceScopeFactory = serviceScopeFactory;
      this.repository = repository;
    }

    [HttpPost("save")]
    public IActionResult Save()
    {
      this.repository.Save();

      return Ok();
    }


    [HttpPost("saveV2")]
    public IActionResult Save(string type)
    {
      ArgumentNullException.ThrowIfNull(type);

      // Service Locator Pattern yöntemi
      // Low Couple servis çağrı yöntemi.
      IRepository repository = this.serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredKeyedService<IRepository>(type);

      ArgumentNullException.ThrowIfNull(repository);
      repository.Save();
      

      return Ok();
    }
  }
}
