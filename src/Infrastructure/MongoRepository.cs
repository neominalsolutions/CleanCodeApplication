using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  // Open Closed olmayan hali
  public class Repository : IRepository
  {
    private readonly string type;
    public Repository(string type)
    {
      this.type = type;
    }
    public void Save()
    {

      if (this.type == "Mongo")
      {
        new MongoRepository().Save();
      }
      else if (this.type == "MsSql")
      {
        new MsSqlRepository().Save();
      }

    }
  }

  public class MongoRepository : IRepository
  {
    public void Save()
    {
      Console.Out.WriteLineAsync("Mongo Save");
    }
  }
}
