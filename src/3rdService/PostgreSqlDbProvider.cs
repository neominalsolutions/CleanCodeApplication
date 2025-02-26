using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdService
{
  public class PostgreSqlDbProvider
  {
    public void ExecuteSql(string sql)
    {
      Console.WriteLine("Postgres Executing SQL: " + sql);
    }
  }
}
