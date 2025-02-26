using Infrastructure.Core;

namespace Infrastructure
{
  public class MsSqlRepository : IRepository
  {
    public void Save()
    {
      Console.Out.WriteLineAsync("MsSql Save");
    }
  }
}
