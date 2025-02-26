using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
  public interface IReadOnlyRepo<T> where T : class
  {
    T FindBy(string id);
  }

  public interface IWriteOnlyRepo
  {
    void Save();
  }

  public interface IRepo<T>:IWriteOnlyRepo, IReadOnlyRepo<T>
    where T : class
  {
    //void Save();
    //T FindBy(string id);
  }

  public class A
  {

  }
  public class ARepository : IRepo<A>
  {
    public A FindBy(string id)
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      throw new NotImplementedException();
    }
  }

  public class AReadOnly : IReadOnlyRepo<A>
  {
    public A FindBy(string id)
    {
      throw new NotImplementedException();
    }
  }


  // OPEN CLOSED için ortak interface
  public interface IRepository
  {
    void Save();
  }
}
