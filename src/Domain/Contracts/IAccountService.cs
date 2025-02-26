using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
  // Application Katmanında Domain Katmanındaki AccountService Nesnesinin çağrılması için kullanılacak olan Interface , Port
  public interface IAccountService
  {
      void DrawMoney(decimal amount);
  }
}
