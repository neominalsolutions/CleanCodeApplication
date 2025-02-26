using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  // IAccountRepository bu port üzerinden Domain Layer Infra Layer direkt olarak bağlımı olmadan haberleşir.
  public class AccountRepository : IAccountRepository // Bu Class ise Adapter Class
  {
    public void Save()
    {
      Console.Out.WriteLine("Para Transfer işlemi gerçekleşti");
    }
  }
}
