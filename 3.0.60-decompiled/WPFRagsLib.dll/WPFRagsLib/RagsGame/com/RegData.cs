using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsLib.RagsGame.com;

[Serializable]
[DataContract(Name = "RegData", Namespace = "http://tempuri.org/")]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DebuggerStepThrough]
public class RegData : IExtensibleDataObject, INotifyPropertyChanged
{
	[NonSerialized]
	private ExtensionDataObject a;

	private int retvalField;

	private DateTime expireField;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return a;
		}
		set
		{
			a = value;
		}
	}

	[DataMember(IsRequired = true)]
	public int retval
	{
		get
		{
			return retvalField;
		}
		set
		{
			if (!retvalField.Equals(value))
			{
				retvalField = value;
				RaisePropertyChanged("retval");
			}
		}
	}

	[DataMember(IsRequired = true, Order = 1)]
	public DateTime expire
	{
		get
		{
			return expireField;
		}
		set
		{
			if (!expireField.Equals(value))
			{
				expireField = value;
				RaisePropertyChanged("expire");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
