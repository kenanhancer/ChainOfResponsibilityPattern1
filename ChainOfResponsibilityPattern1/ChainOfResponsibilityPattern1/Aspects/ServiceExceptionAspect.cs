using System;

public class ServiceExceptionAspect : IInvocation
{
    public object Intercept(string method, Func<object> proceed)
    {
        Console.WriteLine($"ServiceExceptionAspect: {method} method begins at {DateTime.Now}");

        object result = null;

        try
        {
            result = proceed.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine($"ServiceExceptionAspect: {method} method ends at {DateTime.Now}");

        return result;
    }
}