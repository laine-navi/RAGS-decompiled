using System;

namespace Polenter.Serialization;

[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public sealed class ExcludeFromSerializationAttribute : Attribute
{
}
