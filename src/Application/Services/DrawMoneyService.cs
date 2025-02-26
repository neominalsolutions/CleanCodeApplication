using Application.Requests;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
  public class DrawMoneyService : IDrawMoneyService
  {
    private readonly IAccountService accountService; // DIP

    public DrawMoneyService(IAccountService accountService)
    {
      this.accountService = accountService;
    }

    public Task HandleAsyc(DrawMoneyRequest request, CancellationToken token)
    {
      this.accountService.DrawMoney(request.money); // Application Layer => Domain Layer isteği gönderdi.

      // event fırlatma
      // loglama
      // validayon kontrolü

      return Task.CompletedTask;
    }
  }
}
