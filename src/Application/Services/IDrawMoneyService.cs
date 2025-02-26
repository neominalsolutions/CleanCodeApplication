using Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
  public interface IDrawMoneyService
  {
    Task HandleAsyc(DrawMoneyRequest request,CancellationToken token);
  }
}
