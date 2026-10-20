using System;

namespace Polenter.Serialization.Core;

public abstract class Property
{
	public string Name { get; set; }

	public Type Type { get; set; }

	public Property Parent { get; set; }

	public PropertyArt Art => GetPropertyArt();

	protected Property(string name, Type type)
	{
		Name = name;
		Type = type;
	}

	protected abstract PropertyArt GetPropertyArt();

	public static Property CreateInstance(PropertyArt art, string propertyName, Type propertyType)
	{
		return art switch
		{
			PropertyArt.Collection => (Property)new CollectionProperty(propertyName, propertyType), 
			PropertyArt.Complex => new ComplexProperty(propertyName, propertyType), 
			PropertyArt.Dictionary => new DictionaryProperty(propertyName, propertyType), 
			PropertyArt.MultiDimensionalArray => new MultiDimensionalArrayProperty(propertyName, propertyType), 
			PropertyArt.Null => new NullProperty(propertyName), 
			PropertyArt.Reference => null, 
			PropertyArt.Simple => new SimpleProperty(propertyName, propertyType), 
			PropertyArt.SingleDimensionalArray => new SingleDimensionalArrayProperty(propertyName, propertyType), 
			_ => throw new InvalidOperationException($"Unknown PropertyArt {art}"), 
		};
	}

	public override string ToString()
	{
		string text = Name ?? "null";
		string text2 = (((object)Type == null) ? "null" : Type.Name);
		string text3 = ((Parent == null) ? "null" : Parent.GetType().Name);
		return string.Format("{0}, Name={1}, Type={2}, Parent={3}", new object[4]
		{
			GetType().Name,
			text,
			text2,
			text3
		});
	}
}
