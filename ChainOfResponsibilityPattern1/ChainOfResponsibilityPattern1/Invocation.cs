using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Invocation : IInvocation
{
    private readonly IList<IInvocation> _invocations;

    public Invocation(IList<IInvocation> invocations)
    {
        _invocations = invocations;
    }

    public virtual void Intercept(string method, Action proceed)
    {
        Intercept(method, () => { proceed(); return null; });
    }

    public virtual TResult Intercept<TResult>(string method, Func<TResult> proceed)
    {
        return (TResult)Intercept(0, method, () => proceed());
    }

    public virtual object Intercept(string method, Func<object> proceed)
    {
        return Intercept(0, method, proceed);
    }

    private object Intercept(int i, string method, Func<object> proceed)
    {
        IInvocation invocation = _invocations.ElementAtOrDefault(i);

        if (invocation == null)
        {
            return proceed();
        }

        return invocation.Intercept(method, () => Intercept(++i, method, proceed));
    }
}