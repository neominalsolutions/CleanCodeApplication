using _3rdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
  public interface IDbProviderAdapter
  {
    public void ExecuteSql(string sql);
  }

  // Client Class
  public class DbProviderAdapter : IDbProviderAdapter
  {
    private readonly string _serviceName;
    private readonly MsSqlDbProvider msSqlDbProvider = new MsSqlDbProvider();
    private readonly PostgreSqlDbProvider postgreSqlDbProvider = new PostgreSqlDbProvider();

    public DbProviderAdapter(string serviceName)
    {
      _serviceName = serviceName;
    }

    public void ExecuteSql(string sql)
    {

      if (_serviceName == "MSSQL")
      {
        msSqlDbProvider.ExecuteSql(sql);
      }
      else if (_serviceName == "POSTGRESQL")
      {
        postgreSqlDbProvider.ExecuteSql(sql);
      }
      else
      {
        throw new Exception("Invalid Service Name");
      }

    }
  }

}
