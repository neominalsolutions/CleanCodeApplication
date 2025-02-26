using Aspect.Core;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
  // [LogPerformace("Deneme")]
  public class AccountService : IAccountService
  {

    // [LogPerformace] // Attribute
    [LogPerformace("Deneme")]
    public void DrawMoney(decimal amount)
    {
      // var sp = Stopwatch.StartNew(); // cross cutting concern
      Console.Out.WriteLine("Para çekme işlemi");
      Thread.Sleep(5000);
      // sp.Stop();
    }
  }
}
