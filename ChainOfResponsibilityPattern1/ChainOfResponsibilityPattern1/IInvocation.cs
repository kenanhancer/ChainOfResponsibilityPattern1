using System;

public interface IInvocation
{
    object Intercept(string method, Func<object> proceed);
}