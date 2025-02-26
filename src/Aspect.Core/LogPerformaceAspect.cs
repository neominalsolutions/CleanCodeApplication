using Castle.DynamicProxy;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace Aspect.Core
{

  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  public class LogPerformaceAttribute : Attribute
  {
    public string Name { get; set; }
    public LogPerformaceAttribute(string name)
    {
      Name = name;
    }
  }

  // Kodun arasına girme işleminden sorumlu sınıf.
  public class LogPerformaceAspect : IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
      try
      {

        var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;

        var hasAttribute = methodInfo.GetCustomAttributes(typeof(LogPerformaceAttribute), true).Length > 0;

        var attribute = methodInfo.GetCustomAttribute<LogPerformaceAttribute>();
        ArgumentNullException.ThrowIfNull(attribute);
        Console.WriteLine("AttributeName Value " + attribute.Name);

        if (hasAttribute)
        {
          // OnBefore => Request
          var sp = Stopwatch.StartNew();
          invocation.Proceed(); // Methodu devam ettir // OnContinue
          sp.Stop();
          Console.Out.WriteLine($"toplam süre {sp.ElapsedMilliseconds} ms"); // OnAfter => Response
        }
        else
        {
          invocation.Proceed(); // attribute tanımı yoksa koda devam et.
        }

      }
      catch (Exception ex)
      {
        Console.Out.WriteLine("Code Interception kısmında hata oluştu");
      }
    }
  }
}
