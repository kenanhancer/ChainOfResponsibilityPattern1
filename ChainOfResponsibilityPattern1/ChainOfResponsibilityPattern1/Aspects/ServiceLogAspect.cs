using System;

public class ServiceLogAspect : IInvocation
{
    public object Intercept(string method, Func<object> proceed)
    {
        Console.WriteLine($"ServiceLogAspect: {method} method begins at {DateTime.Now}");

        object result = proceed.Invoke();

        Console.WriteLine($"ServiceLogAspect: {method} method ends at {DateTime.Now}");

        return result;
    }
}