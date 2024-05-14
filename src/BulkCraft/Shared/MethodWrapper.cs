using System;
using System.Reflection;

namespace BulkCraft.Shared;

public class MethodWrapper<T> where T : Delegate
{
    private readonly MethodInfo method;
    private readonly object obj;
    private T invoke;

    // create a constructor that takes a MethodInfo
    public MethodWrapper(MethodInfo method, object obj = null)
    {
        this.method = method;
        this.obj = obj;
    }

    public T Invoke => invoke ??= (T)Delegate.CreateDelegate(typeof(T), obj, method);
}
