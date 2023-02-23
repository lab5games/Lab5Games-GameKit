using System;

namespace Lab5Games
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LazyInstantiateAttribute : Attribute
    {
    }
}
