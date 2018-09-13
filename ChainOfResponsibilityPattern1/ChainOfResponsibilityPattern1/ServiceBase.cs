using System.Collections.Generic;

public abstract class ServiceBase : Invocation
{
    public ServiceBase(IList<IInvocation> aspects) : base(aspects)
    {
    }
}